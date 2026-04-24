using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Domain.IRepository
{
    public interface IUnitOfWork
    {
        IBlockCountryRepository BlockCountryRepository { get; }
        ILogRepository LogRepository { get; }
    }
}
