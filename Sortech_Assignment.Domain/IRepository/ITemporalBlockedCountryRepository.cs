using Sortech_Assignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Domain.IRepository
{
    public interface ITemporalBlockedCountryRepository
    {
        public bool AddTempBlockedCountry(string countryCode, DateTime UnblockTime);
    }
}
