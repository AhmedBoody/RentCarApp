using Dapper;
using RentCarApp.Application.Configuration.Data;
using RentCarApp.Domain.Cities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Application.Cities.DomainServices
{
    public class CityUniquenessChecker : ICityUniquenessChecker
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;
        public CityUniquenessChecker(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public bool IsUnique(string nameAr,string nameEn)
        {
            var connection = this._sqlConnectionFactory.GetOpenConnection();

            const string sql = "SELECT TOP 1 1" +
                               "FROM [lookups].[Cities] AS [Cities] " +
                               "WHERE [Cities].[NameAr] = @nameAr" +
                               "OR [Cities].[NameEn] = @nameEn";
            var cityKey = connection.QuerySingleOrDefault<int?>(sql,
                            new
                            {
                                NameAr = nameAr,
                                NameEn = nameEn
                            });

            return !cityKey.HasValue;
        }
    }
}
