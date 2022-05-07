using DynamexApp.Business.DTOs;
using DynamexApp.Business.HelperService.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Business.HelperService.Implementations
{
    public class FileManager : IFileManager
    {
        private readonly IHelperAccessor _helperAccessor;

        public FileManager(IHelperAccessor helperAccessor)
        {
            _helperAccessor = helperAccessor;
        }

        public void DeleteFile(string folder, string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/uploads",folder, fileName);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

        public async Task<SavedFileDto> Save(IFormFile file,string folder)
        {
            string NewfileName = Guid.NewGuid().ToString() + file.FileName;
            string rooting = Path.Combine(Directory.GetCurrentDirectory()+"/wwwroot/uploads",folder);
            string resultPath = Path.Combine(rooting, NewfileName);

            SavedFileDto savedFileDto = new SavedFileDto
            {
                FileName = file.FileName,
                ChangedFileName = NewfileName,
                Path = _helperAccessor.BaseUrl+"/uploads/Brands/"+ NewfileName
            };

            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return savedFileDto;
        }
    }
}
