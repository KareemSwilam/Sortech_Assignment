using Sortech_Assignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Domain.IRepository
{
    public interface ILogRepository
    {
         public void AddLog(Log log);
         public List<Log> GetLogs(Func<Log, bool>? filter = null, int PageNumber = 1, int PageSize = 10);
         
    }
}
