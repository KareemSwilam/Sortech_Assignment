using FluentValidation;
using Sortech_Assignment.Application.Dtos.CountryDtos;

namespace Sortech_Assignment.Application.Validation
{
    public class IPLockupDtoValidator : AbstractValidator<IPLockupDto>
    {
        public IPLockupDtoValidator()
        {
            RuleFor(x => x.IPAddress)
                .Must(IpValid)
                .When(x => !string.IsNullOrEmpty(x.IPAddress))
                .WithMessage("Invalid IP address format.");

        }
        private bool IpValid(string ip)
        {
            var segment = ip.Split('.');
            if (segment.Length != 4)
            {
                return false;
            }

            foreach (var item in segment)
            {
                if (!int.TryParse(item, out int value) || value < 0 || value > 255)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
    
    