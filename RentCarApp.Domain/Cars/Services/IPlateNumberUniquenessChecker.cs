using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Cars.Services
{
    public interface IPlateNumberUniquenessChecker
    {
        bool IsUnique(string plateNumber,string id = null);
    }
}
