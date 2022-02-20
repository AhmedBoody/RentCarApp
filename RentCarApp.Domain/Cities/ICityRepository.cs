using System.Collections.Generic;
using System.Threading.Tasks;

namespace RentCarApp.Domain.Cities
{
    public interface ICityRepository
    {
        Task<City> GetByIdAsync(CityId id);
        Task AddAsync(City city);
        void UpdateAsync(City city);
        Task DeleteAsync(CityId id);
        Task<List<City>> GetList(string search);
    }
}
