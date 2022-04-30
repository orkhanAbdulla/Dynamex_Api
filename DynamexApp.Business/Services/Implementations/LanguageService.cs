using AutoMapper;
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
            Language language = _mapper.Map<Language>(languageDTO);
            await _unitOfWork.LanguageRepository.InsertAsync(language);
            await _unitOfWork.CommitAsync();
        }

        public async void Delete(int id)
        {
            Language language = await _unitOfWork.LanguageRepository.GetAsync(x => x.Id == id);
            _unitOfWork.LanguageRepository.Remove(language);
        }

        public async Task EditAsync(int id, LanguagePostDTO languageDTO)
        {
            Language language = await _unitOfWork.LanguageRepository.GetAsync(x => x.Id == id);
            language = _mapper.Map<Language>(languageDTO);
            await _unitOfWork.LanguageRepository.InsertAsync(language);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Language>> GetAllLanguagesAsync(Expression<Func<Language, bool>> filter = null)
        {
            return await _unitOfWork.LanguageRepository.GetAllAsync(x => x.IsDeleted == false);
        }

        public async Task<LanguageGetDTO> GetLanguageAsync(int id)
        {
            var language = await _unitOfWork.LanguageRepository.GetAsync(x => x.Id == id);
            LanguageGetDTO languageGetDTO = _mapper.Map<LanguageGetDTO>(language);
            return languageGetDTO;
        }

        //public async Task<bool> IsExistLanguageAsync(Expression<Func<Language, bool>> filter)
        //{
            
        //}
    }
}
