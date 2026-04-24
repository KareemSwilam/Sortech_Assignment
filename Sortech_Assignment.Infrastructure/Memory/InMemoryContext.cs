using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sortech_Assignment.Domain.Models;

namespace Sortech_Assignment.Infrastructure.Memory
{
    public class InMemoryContext
    {
        public ConcurrentDictionary<string, Country> BlockedCountry { get; set; } = new();
        public List<Log> Logs { get; set; } = new List<Log>();  
    }
}
