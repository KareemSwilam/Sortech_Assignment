using Sortech_Assignment.Domain.IRepository;

namespace Sortech_Assignment.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBlockCountryRepository BlockCountryRepository { get; private set; }
        public ILogRepository LogRepository { get; private set; }
        public ITemporalBlockedCountryRepository TemporalBlockedCountryRepository { get; private set; }
        public UnitOfWork(IBlockCountryRepository blockCountryRepository,
                          ILogRepository logRepository,
                          ITemporalBlockedCountryRepository temporalBlockedCountryRepository)
        {
            BlockCountryRepository = blockCountryRepository;
            LogRepository = logRepository;
            TemporalBlockedCountryRepository = temporalBlockedCountryRepository;
        }
    }
}
