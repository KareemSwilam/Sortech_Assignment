using Sortech_Assignment.Domain.IRepository;
using Sortech_Assignment.Domain.Models;
using Sortech_Assignment.Infrastructure.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public List<Log> GetLogs(Func<Log, bool>? filter = null, int PageNumber = 1, int PageSize = 10)
        {
            var logs = _context.Logs.AsQueryable();
            if(filter != null)
            {
                logs = logs.Where(filter).AsQueryable();
            }
            logs = logs.Skip((PageNumber - 1) * PageSize).Take(PageSize);   
            return logs.ToList();
        }
    }
}
