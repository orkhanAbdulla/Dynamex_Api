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
        public async Task<SavedFileDto> Save(IFormFile file,string folder)
        {
            if (file == null)
                throw new Exception("file null ola bilmez");
            if (file.ContentType != "image/jpeg" && file.ContentType != "image/png")
                throw new Exception("File formati yanlishdi");

            string NewfileName = Guid.NewGuid().ToString() + file.FileName;
            string rooting = Path.Combine(Directory.GetCurrentDirectory()+"/wwwroot/uploads",folder);
            string resultPath = Path.Combine(rooting, NewfileName);

            SavedFileDto savedFileDto = new SavedFileDto
            {
                FileName = file.FileName,
                ChangedFileName = NewfileName,
                Path = ""
            };

            using (FileStream fileStream = new FileStream(resultPath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return savedFileDto;
        }
    }
}
