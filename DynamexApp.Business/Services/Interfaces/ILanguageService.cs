using DynamexApp.Business.DTOs.LanguageDTO;
using DynamexApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Business.Services.Interfaces
{
    public interface ILanguageService
    {
        Task<LanguageGetDTO> GetLanguageAsync(int id);
        Task<IEnumerable<LanguageGetDTO>> GetAllLanguagesAsync(Expression<Func<Language,bool>> filter=null);
        Task CreateAsync(LanguagePostDTO languageDTO);
        Task EditAsync(int id, LanguagePostDTO languageDTO);
        Task Delete(int id);

        //Task<bool> IsExistLanguageAsync(Expression<Func<Language, bool>> filter);

    }
}
