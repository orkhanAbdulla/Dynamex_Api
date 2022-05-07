using DynamexApp.Core.Entities;
using DynamexApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Data.Repositories
{
    public class CountryBrandRepository:Repository<CountryBrand>,ICountryBrandRepository
    {
        private readonly AppDbContext _context;

        public CountryBrandRepository(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task InsertCountryBrandAsync(List<CountryBrand> countryBrand)
        {
            await _context.CountryBrands.AddRangeAsync(countryBrand);

        }
    }
}
