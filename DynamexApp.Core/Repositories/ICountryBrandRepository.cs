using DynamexApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Core.Repositories
{
    public interface ICountryBrandRepository:IRepository<CountryBrand>
    {
       Task InsertCountryBrandAsync(List<CountryBrand> entity);
      
    }
}
