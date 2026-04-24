using FluentValidation;
using Sortech_Assignment.Application.Dtos.CountryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Application.Validation
{
    public class TemporalBlockedCountryDtoValidator: AbstractValidator<TemporalBlockedCountryDto>
    {
        public TemporalBlockedCountryDtoValidator()
        {
            RuleFor(x => x.CountryCode)
                .NotEmpty().WithMessage("Country code is required.")
                .MinimumLength(2).MaximumLength(3).WithMessage("Country code must be 2 or 3 characters long.");
            RuleFor(x => x.DurationMinutes)
                .InclusiveBetween(0, 1440).WithMessage("Duration must be greater than 0 minutes And less than 1440 minutes.");
        }
    }
}
