using Sortech_Assignment.Domain.IRepository;
using Sortech_Assignment.Infrastructure.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Infrastructure.Repository
{
    public class TemporalBlockedCountryRepository : ITemporalBlockedCountryRepository
    {
        private readonly InMemoryContext _context;
        public TemporalBlockedCountryRepository(InMemoryContext context)
        {
            _context = context;
        }
        public bool AddTempBlockedCountry(string countryCode, DateTime UnblockTime)
        {
            return _context.TemporarilyBlockedCountry.TryAdd(countryCode, UnblockTime);
        }
    }
}
