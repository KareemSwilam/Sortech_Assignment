using Sortech_Assignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Domain.IRepository
{
    public interface IBlockCountryRepository
    {
        public bool AddBlockedCountry(string countryCode , Country country);
        public bool RemoveBlockedCountry(string countryCode);
        public bool IsBlocked(string countryCode);
        public List<Country> GetBlockedCountryList(Func<Country,bool>? filter = null);
        public Country GetBlockedCountry(string countryCode);
    }
}
