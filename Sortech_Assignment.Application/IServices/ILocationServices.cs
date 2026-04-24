using Sortech_Assignment.Application.Dtos.CountryDtos;
using Sortech_Assignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Application.IServices
{
    public interface ILocationServices
    {
        public Task<Country> GetCountryByCode(string code);
        public Task<GetCountryByIPResponseDto> GetCountryByIPAdress(string? ipAddress = null);
    }
}
