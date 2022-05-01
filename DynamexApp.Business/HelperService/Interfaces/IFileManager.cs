using DynamexApp.Business.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Business.HelperService.Interfaces
{
    public interface IFileManager
    {
        Task<SavedFileDto> Save(IFormFile file,string folder);
    }
}
