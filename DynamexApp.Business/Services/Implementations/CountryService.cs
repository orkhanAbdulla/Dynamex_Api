using AutoMapper;
using DynamexApp.Business.CustomExceptions;
using DynamexApp.Business.DTOs.CountryDTO;
using DynamexApp.Business.Services.Interfaces;
using DynamexApp.Core;
using DynamexApp.Core.Entities;
using DynamexApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Business.Services.Implementations
{
    public class CountryService:ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(CountryPostDTO countryPostDTO)
        {
            if (await _unitOfWork.CountryRepository.IsExistAsync(x => x.Name.ToLower() == countryPostDTO.Name.ToLower()))
                throw new RecordAlreadyExistException($"Item already exist");
            Country country = _mapper.Map<Country>(countryPostDTO);
            await _unitOfWork.CountryRepository.InsertAsync(country);
            await _unitOfWork.CommitAsync();
        }
        public async Task Delete(int id)
        {
            Country country = await _unitOfWork.CountryRepository.GetAsync(x => x.Id == id);
            if (country == null) throw new ItemNotFoundException($"item not found by:{id}");
            country.IsDeleted = true;
            await _unitOfWork.CommitAsync();
        }
        public async Task EditAsync(int id, CountryEditDTO countryPostDTO)
        {
            Country country = await _unitOfWork.CountryRepository.GetAsync(x=>x.IsDeleted==false &&x.Id==id);
            if (country == null) throw new ItemNotFoundException($"item not found by:{id}");
            if (await _unitOfWork.CountryRepository.IsExistAsync(x => x.Name.ToLower() == countryPostDTO.Name.ToLower()))
                throw new RecordAlreadyExistException($"Item already exist");
            _mapper.Map<CountryEditDTO, Country>(countryPostDTO, country);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<CountryGetDto>> GetAllCountryAsync(string languageCode)
        {
            IEnumerable<Country> countries = await _unitOfWork.CountryRepository.GetAllAsync(x=>x.IsDeleted==false && x.Language.Code== languageCode, "Language");
            IEnumerable<CountryGetDto> countryListDTOs = _mapper.Map<IEnumerable<CountryGetDto>>(countries);
            return countryListDTOs;
        }
        public async Task<CountryGetDto> GetCountryAsync(int id)
        {
            Country country = await _unitOfWork.CountryRepository.GetAsync(x=>x.IsDeleted==false&&x.Id==id);
            if (country==null) throw new ItemNotFoundException($"item not found by:{id}");
            CountryGetDto countryGetDto = _mapper.Map<CountryGetDto>(country);
            return countryGetDto;
        }
    }
}
