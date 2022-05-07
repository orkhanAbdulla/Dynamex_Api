using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Business.DTOs.BrandDto
{
    public class BrandPostDto
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public IFormFile File { get; set; }
        public IEnumerable<int> CountryIds { get; set; }
      
    }
    public class BrandPostDtoValidatotr : AbstractValidator<BrandPostDto>
    {
        public BrandPostDtoValidatotr()
        {
            RuleFor(x=>x.Name).MaximumLength(20).NotNull().NotEmpty();
            RuleFor(x=>x.Link).MaximumLength(100).NotNull().NotEmpty();
            RuleFor(x => x.CountryIds).NotNull().NotEmpty();
        }
    }
}
