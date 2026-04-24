using Sortech_Assignment.Application.Dtos.LogDtos;
using Sortech_Assignment.Application.Result;
using Sortech_Assignment.Domain.Models;
using Sortech_Assignment.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Application.IServices
{
    public interface ILogServices
    {
        public Task<CustomResult<PaginationResult<Log>>> GetAllLogs(LogPaginationParams @params);
    }
}
