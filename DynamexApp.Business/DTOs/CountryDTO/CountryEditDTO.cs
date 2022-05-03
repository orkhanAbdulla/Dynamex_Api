using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Business.DTOs.CountryDTO
{
    public class CountryEditDTO
    {
        public string Name { get; set; }

        public class CountryEditDTOValidator : AbstractValidator<CountryEditDTO>
        {
            public CountryEditDTOValidator()
            {
                RuleFor(x=>x.Name).MinimumLength(3).MaximumLength(20).NotNull().NotEmpty();
            }
        }
    }
}
