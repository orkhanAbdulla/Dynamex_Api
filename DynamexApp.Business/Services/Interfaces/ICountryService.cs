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
        Task EditAsync(int id, CountryEditDTO countryPostDTO);
        Task<CountryGetDto> GetCountryAsync(int id);
        Task<IEnumerable<CountryGetDto>> GetAllCountryAsync(string code);
    }
}
