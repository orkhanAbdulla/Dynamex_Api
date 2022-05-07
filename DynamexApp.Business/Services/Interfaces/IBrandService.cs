using DynamexApp.Business.DTOs;
using DynamexApp.Business.DTOs.BrandDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Business.Services.Interfaces
{
    public interface IBrandService
    {
        Task<BrandReturnDto> CreateAsync(BrandPostDto brandPostDto);
        Task DeleteAsync(int id);
        Task EditAsync(int id, BrandPostDto brandPostDto);
        Task<BrandGetDTO> GetBrandAsync(int id);
        Task<IEnumerable<BrandGetDTO>> GetAllBrandAsync(int countryId);
        Task<PagenetedListDTO<BrandListItemDto>> GetAllFiltred(int page, string search);
        Task<bool> isExistByIdAsync(int id);
    }
}
