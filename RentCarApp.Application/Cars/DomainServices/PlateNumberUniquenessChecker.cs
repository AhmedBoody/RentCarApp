using Dapper;
using RentCarApp.Application.Configuration.Data;
using RentCarApp.Domain.Cars;
using RentCarApp.Domain.Cars.Services;
using RentCarApp.Domain.Cities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Application.Cities.DomainServices
{
    public class PlateNumberUniquenessChecker : IPlateNumberUniquenessChecker
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public PlateNumberUniquenessChecker(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public bool IsUnique(string plateNumber,string id = null)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();

            const string sql = @"SELECT TOP 1 1 
                                FROM [app].[Cars] AS [Cars]  
                                WHERE [Cars].[PlateNumber] = @plateNumber   
                                AND (@id IS NULL OR Id != @id)  ";
            var cityKey = connection.QuerySingleOrDefault<int?>(sql,
                            new
                            {
                                PlateNumber = plateNumber,
                                id = id,
                            });

            return !cityKey.HasValue;
        }
    }
}
