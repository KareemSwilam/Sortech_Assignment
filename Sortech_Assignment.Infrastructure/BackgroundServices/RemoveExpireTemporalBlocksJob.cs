using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Sortech_Assignment.Infrastructure.Memory;

namespace Sortech_Assignment.Infrastructure.BackgroundServices
{
    public class RemoveExpireTemporalBlocksJob : BackgroundService
    {
        private readonly InMemoryContext _context;
        public RemoveExpireTemporalBlocksJob(InMemoryContext context)
        {
            _context = context;
        }
        protected override async  Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(
            TimeSpan.FromMinutes(1));

            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                Console.WriteLine("Checking for expired temporal blocks...");
                try {var expireBlocksCode = _context.TemporarilyBlockedCountry.Where(b => b.Value <= DateTime.UtcNow).Select(b => new { code = b.Key, unblockTime = b.Value }).ToList();
                    foreach (var Country in expireBlocksCode)
                    {
                        var Saved1 = _context.TemporarilyBlockedCountry.TryRemove(Country.code, out _);
                        if (Saved1)
                        {
                            var Saved2 = _context.BlockedCountry.TryRemove(Country.code, out _);
                            if (!Saved2)
                            {
                                _context.TemporarilyBlockedCountry.TryAdd(Country.code, Country.unblockTime);
                                Console.WriteLine($"Failed to remove expired block for country code: {Country.code}");
                            }
                            Console.WriteLine($"Succes to remove expired block for country code: {Country.code} ");
                        }
                        else
                        {
                            Console.WriteLine($"Failed to remove expired block for country code: {Country.code}");
                        }
                        
                    }
                }
                catch(Exception ex)
                {
                    // Log the exception
                    Console.WriteLine($"An error occurred while removing expired blocks: {ex.Message}");
                }
            }
        }
    }
}
