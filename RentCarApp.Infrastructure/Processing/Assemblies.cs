using System.Reflection;
using RentCarApp.Application.Customers;

namespace RentCarApp.Infrastructure.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(MarkCustomerAsWelcomedCommand).Assembly;
    }
}