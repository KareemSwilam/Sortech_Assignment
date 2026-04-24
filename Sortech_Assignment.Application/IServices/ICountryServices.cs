using Sortech_Assignment.Application.Common;
using Sortech_Assignment.Application.Dtos.CountryDtos;
using Sortech_Assignment.Application.Result;
using Sortech_Assignment.Domain.Models;
using Sortech_Assignment.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Application.IServices
{
    public interface ICountryServices
    {
        public Task<CustomResult> AddBlockedCoutry(string coutryCode);
        public Task<CustomResult> RemoveBlockedCoutry(string coutryCode);
        public Task<CustomResult<PaginationResult<Country>>> GetAllCountry(CountryPaginationParams @params);
        public Task<CustomResult<Country>> GetCountryByIPAdress(string? ipAddress);
        public Task<CustomResult<string>> CheckBlock();  
        public Task<CustomResult> AddTemporalBlockedCountry(TemporalBlockedCountryDto dto);

    }
}
