using DynamexApp.Business.DTOs.CountryDTO;
using DynamexApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Business.Services.Interfaces
{
    public interface ICountryService
    {
        Task CreateAsync(CountryPostDTO countryPostDTO);
        Task Delete(int id);
        Task EditAsync(int id, CountryPostDTO countryPostDTO);
        Task<CountryGetDto> GetLanguageAsync(int id);
        Task<IEnumerable<CountryListDTO>> GetAllLanguagesAsync(Expression<Func<Country, bool>> filter = null);
    }
}
