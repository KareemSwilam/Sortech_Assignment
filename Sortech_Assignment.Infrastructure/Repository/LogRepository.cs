using Sortech_Assignment.Domain.IRepository;
using Sortech_Assignment.Domain.Models;
using Sortech_Assignment.Domain.ValueObject;
using Sortech_Assignment.Infrastructure.Memory;

namespace Sortech_Assignment.Infrastructure.Repository
{
    public class LogRepository : ILogRepository
    {
        private readonly InMemoryContext _context;
        public LogRepository(InMemoryContext context)
        {
            _context = context;
        }

        public void AddLog(Log log)
        {
            _context.Logs.Add(log);
        }

        public PaginationResult<Log> GetLogs(Func<Log, bool>? filter = null, int PageNumber = 1, int PageSize = 10)
        {
            var logs = _context.Logs.AsQueryable();
            
            if (filter != null)
            {
                logs = logs.Where(filter).AsQueryable();
            }
            var Count = logs.Count();

            logs = logs.Skip((PageNumber - 1) * PageSize).Take(PageSize);

            return new PaginationResult<Log>(Count, PageNumber,PageSize, logs);
        }
    }
}
