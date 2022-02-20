using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentCarApp.Domain.Cities;
using RentCarApp.Infrastructure.Database;
using RentCarApp.Infrastructure.SeedWork;

namespace RentCarApp.Infrastructure.Domain.Cities
{
    public class CityRepository : ICityRepository
    {
        private readonly RentCarContext _context;

        public CityRepository(RentCarContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(City City)
        {
            await this._context.Cities.AddAsync(City);
        }

        public async Task DeleteAsync(CityId id)
        {
            var deletedCity = await GetByIdAsync(id);
            if (deletedCity != null)
                _context.Cities.Remove(deletedCity);
        }

        public async Task<City> GetByIdAsync(CityId id)
        {
            return await this._context.Cities
                .SingleAsync(x => x.Id == id);
        }

        public async Task<List<City>> GetList(string search)
        {
            return await _context.Cities.Where(w => w.nameAr.ToLower().Contains(search.ToLower()) || w.nameEn.ToLower().Contains(search.ToLower())).ToListAsync();
        }

        public  void UpdateAsync(City city)
        {
            _context.Cities.Update(city);
        }
    }
}