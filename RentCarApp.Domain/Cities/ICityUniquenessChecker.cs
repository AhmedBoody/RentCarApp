using System;
using System.Collections.Generic;
using System.Text;

namespace RentCarApp.Domain.Cities
{
    public interface ICityUniquenessChecker
    {
        bool IsUnique(string nameAr, string nameEn ,string id = null);
    }
}
