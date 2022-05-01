using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Business.DTOs.CountryDTO
{
    public class CountryPostDTO
    {
        public string Name { get; set; }
        public int LanguageId { get; set; }

       public class CountryPostDTOValidator : AbstractValidator<CountryPostDTO>
        {
            public CountryPostDTOValidator()
            {
                RuleFor(x => x.Name).MinimumLength(3).MaximumLength(20).NotNull().NotEmpty();
                RuleFor(x => x.LanguageId).NotNull().NotEmpty();
            }
        }
    }
}
