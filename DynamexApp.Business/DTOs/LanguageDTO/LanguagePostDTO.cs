using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Business.DTOs.LanguageDTO
{
    public class LanguagePostDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
    public class LanguagePostDTOValidator : AbstractValidator<LanguagePostDTO>
    {
        public LanguagePostDTOValidator()
        {
            RuleFor(x => x.Code).Length(2).NotNull();
            RuleFor(x => x.Name).MinimumLength(3).MaximumLength(50).NotNull().NotEmpty();
        }

    }


}
