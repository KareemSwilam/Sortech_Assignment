    using Sortech_Assignment.Domain.IRepository;
using Sortech_Assignment.Domain.Models;
using Sortech_Assignment.Infrastructure.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Infrastructure.Repository
{
    public class BlockCountryRepository : IBlockCountryRepository
    {
        private readonly InMemoryContext _context;
        public BlockCountryRepository(InMemoryContext context)
        {
            _context = context;
        }
        public bool AddBlockedCountry(string countryCode, Country country)
        {
            return _context.BlockedCountry.TryAdd(countryCode, country);

        }

        public Country GetBlockedCountry(string countryCode)
        {
            return _context.BlockedCountry.TryGetValue(countryCode, out var country) ? country : null;
        }

        public List<Country> GetBlockedCountryList(Func<Country, bool>? filter = null, int PageNumber = 1, int PageSize = 10)
        {
            var query = _context.BlockedCountry.Values.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter).AsQueryable();
            }
            return query.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
        }

        public bool IsBlocked(string countryCode)
        {
            return _context.BlockedCountry.ContainsKey(countryCode);
        }

        public bool RemoveBlockedCountry(string countryCode)
        {
            return _context.BlockedCountry.TryRemove(countryCode, out _);
        }
        
    }
}
