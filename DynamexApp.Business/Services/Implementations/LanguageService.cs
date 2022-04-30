using AutoMapper;
using DynamexApp.Business.CustomExceptions;
using DynamexApp.Business.DTOs.LanguageDTO;
using DynamexApp.Business.Services.Interfaces;
using DynamexApp.Core;
using DynamexApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Business.Services.Implementations
{
   public class LanguageService : ILanguageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LanguageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateAsync(LanguagePostDTO languageDTO)
        {
            if (await _unitOfWork.LanguageRepository.IsExistAsync(x => x.Name.ToLower() == languageDTO.Name.ToLower() || x.Code.ToLower() == languageDTO.Code.ToLower()))
                throw new RecordAlreadyExistException($"Item already exist");
            Language language = _mapper.Map<Language>(languageDTO);
            await _unitOfWork.LanguageRepository.InsertAsync(language);
            await _unitOfWork.CommitAsync();
        }

        public async void Delete(int id)
        {
            Language language = await _unitOfWork.LanguageRepository.GetAsync(x => x.Id == id);
            if (language == null) throw new ItemNotFoundException($"item not found by:{id}");
            _unitOfWork.LanguageRepository.Remove(language);
        }

        public async Task EditAsync(int id, LanguagePostDTO languageDTO)
        {
            Language language = await _unitOfWork.LanguageRepository.GetAsync(x => x.Id == id);
            if (language == null) throw new ItemNotFoundException($"item not found by:{id}");
            if (await _unitOfWork.LanguageRepository.IsExistAsync(x =>x.Id!=id && x.Name.ToLower() == languageDTO.Name.ToLower()||x.Code.ToLower()==languageDTO.Code.ToLower()))
                throw new RecordAlreadyExistException($"Item already exist");
            language = _mapper.Map<Language>(languageDTO);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<LanguageListDTO>> GetAllLanguagesAsync(Expression<Func<Language, bool>> filter = null)
        {
            IEnumerable<Language> languages = await _unitOfWork.LanguageRepository.GetAllAsync(filter);
            IEnumerable<LanguageListDTO> languageListDTOs = _mapper.Map<IEnumerable<LanguageListDTO>>(languages);
            return languageListDTOs;
        }

        public async Task<LanguageGetDTO> GetLanguageAsync(int id)
        {
            var language = await _unitOfWork.LanguageRepository.GetAsync(x => x.Id == id);
            if (language == null) throw new ItemNotFoundException($"item not found by:{id}");
           
            LanguageGetDTO languageGetDTO = _mapper.Map<LanguageGetDTO>(language);
            return languageGetDTO;
        }

        //public async Task<bool> IsExistLanguageAsync(Expression<Func<Language, bool>> filter)
        //{
            
        //}
    }
}
