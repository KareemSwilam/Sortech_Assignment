using Sortech_Assignment.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBlockCountryRepository BlockCountryRepository { get; private set; }
        public UnitOfWork(IBlockCountryRepository blockCountryRepository)
        {
            BlockCountryRepository = blockCountryRepository;
        }
    }
}
