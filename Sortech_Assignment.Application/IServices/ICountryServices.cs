using Sortech_Assignment.Application.Result;
using Sortech_Assignment.Domain.Models;
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
        public Task<CustomResult<List<Country>>> GetAllCountry();
    }
}
