using AutoMapper;
using DynamexApp.Business.CustomExceptions;
using DynamexApp.Business.DTOs;
using DynamexApp.Business.DTOs.BrandDto;
using DynamexApp.Business.HelperService.Interfaces;
using DynamexApp.Business.Services.Interfaces;
using DynamexApp.Core;
using DynamexApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Business.Services.Implementations
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;

        public BrandService(IUnitOfWork unitOfWork,IMapper mapper,IFileManager fileManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileManager = fileManager;
        }
        public async Task<BrandReturnDto> CreateAsync(BrandPostDto brandPostDto)
        {
            Brand brand = _mapper.Map<Brand>(brandPostDto);
            SavedFileDto savedFile = null;
            if (await _unitOfWork.BrandRepository.IsExistAsync(x => x.IsDeleted == false && x.Name.ToLower() == brandPostDto.Name.ToLower()))
                throw new RecordAlreadyExistException($"{brandPostDto.Name} already exist");
            if (brandPostDto.File!=null)
            {
                if (brandPostDto.File.ContentType != "image/png" && brandPostDto.File.ContentType != "image/jpeg")
                    throw new FileFormatException("file extention must be png or jpeg");
                savedFile = await _fileManager.Save(brandPostDto.File, "Brands");
                brand.Image = savedFile.ChangedFileName;
            }
            await _unitOfWork.BrandRepository.InsertAsync(brand);
            await _unitOfWork.CommitAsync();

            List<CountryBrand> countryBrands = new List<CountryBrand>();
            foreach (var CountryId in brandPostDto.CountryIds)
            {
                CountryBrand countryBrand = new CountryBrand()
                {
                    BrandId = brand.Id,
                    CountryId = CountryId
                };
                countryBrands.Add(countryBrand);
            }
            await _unitOfWork.ContryBrandRepository.InsertCountryBrandAsync(countryBrands);
            await _unitOfWork.CommitAsync();
            BrandReturnDto brandReturnDto = new BrandReturnDto()
            {
                Id = brand.Id,
                Path= savedFile.Path
            };
            return brandReturnDto;
        }

        public async Task DeleteAsync(int id)
        {
            Brand brand = await _unitOfWork.BrandRepository.GetAsync(x =>x.IsDeleted==false && x.Id == id);
            if (brand == null) throw new ItemNotFoundException($"item not found by:{id}");
            brand.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }
        public async Task EditAsync(int id, BrandPostDto brandPostDto)
        {
            SavedFileDto savedFile = null;
            Brand brand = await _unitOfWork.BrandRepository.GetAsync(x => x.Id == id);
            if (brand == null) throw new ItemNotFoundException($"item not found by:{id}");
            if (await _unitOfWork.BrandRepository.IsExistAsync(x => x.IsDeleted == false && x.Name.ToLower() == brandPostDto.Name.ToLower()))
                throw new RecordAlreadyExistException($"Item already exist");
            _mapper.Map<BrandPostDto,Brand>(brandPostDto, brand);
            if (brandPostDto.File != null)
            {
                if (brandPostDto.File.ContentType != "image/png" && brandPostDto.File.ContentType != "image/jpeg")
                    throw new FileFormatException("file extention must be png or jpeg");
                savedFile = await _fileManager.Save(brandPostDto.File, "Brands");
                 _fileManager.DeleteFile("Brands", brand.Image);
                brand.Image = savedFile.ChangedFileName;
            }
            IEnumerable<CountryBrand> CurrentBrandCountries = await _unitOfWork.ContryBrandRepository.GetAllAsync(x => x.BrandId == brand.Id, "Country");

            //List<CountryBrand> countryBrands = new List<CountryBrand>();
            //foreach (var CountryId in brandPostDto.CountryIds)
            //{
            //    CountryBrand countryBrand = new CountryBrand()
            //    {
            //        BrandId = brand.Id,
            //        CountryId = CountryId
            //    };
            //    countryBrands.Add(countryBrand);
            //}
            //await _unitOfWork.ContryBrandRepository.InsertCountryBrandAsync(countryBrands);
            //await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<BrandGetDTO>> GetAllBrandAsync(int countryId)
        {
            IEnumerable<CountryBrand> countryBrands =await  _unitOfWork.ContryBrandRepository.GetAllAsync(x => x.CountryId == countryId,"Brand");
            List<Brand> brands = new List<Brand>();
            foreach (var item in countryBrands)
            {
                brands.Add(item.Brand);
            }
            List<BrandGetDTO> brandGetDTO = _mapper.Map<List<BrandGetDTO>>(brands);
            return brandGetDTO;
        }

        public async Task<PagenetedListDTO<BrandListItemDto>> GetAllFiltred(int page, string search)
        {
            if (page < 1) throw new PageIndexFormatException("PageIndex must be greater or equal than 1");
            IEnumerable<Brand> brands =await _unitOfWork.BrandRepository.GetAllPagenatedAsync(x=>string.IsNullOrWhiteSpace(search)?true:x.Name.ToLower().Contains(search), page,3);
            int totalCount = await _unitOfWork.BrandRepository.GetTotalCountAsync(x => string.IsNullOrWhiteSpace(search) ? true : x.Name.ToLower().Contains(search));
            List<BrandListItemDto> brandListItemDtos = _mapper.Map<List<BrandListItemDto>>(brands);
            PagenetedListDTO<BrandListItemDto> pagenetedListDTOs = new PagenetedListDTO<BrandListItemDto>(brandListItemDtos, page, totalCount,3);
            return pagenetedListDTOs;
        }

        public async Task<BrandGetDTO> GetBrandAsync(int id)
        {
            Brand brand = await _unitOfWork.BrandRepository.GetAsync(x => x.Id==id &&x.IsDeleted==false);
            if (brand == null) throw new ItemNotFoundException($"item not found by:{id}");
            BrandGetDTO BrandGetDTO = _mapper.Map<BrandGetDTO>(brand);
            return BrandGetDTO;
        }

        public Task<bool> isExistByIdAsync(int id)
        {
            return (_unitOfWork.BrandRepository.IsExistAsync(x => x.Id==id));
        }
    }
}
