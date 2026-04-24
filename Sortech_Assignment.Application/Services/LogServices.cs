using Sortech_Assignment.Application.Dtos.LogDtos;
using Sortech_Assignment.Application.IServices;
using Sortech_Assignment.Application.Result;
using Sortech_Assignment.Domain.IRepository;
using Sortech_Assignment.Domain.Models;
using Sortech_Assignment.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Application.Services
{
    public class LogServices : ILogServices
    {
        private readonly IUnitOfWork _unit;
        public LogServices(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<CustomResult<PaginationResult<Log>>> GetAllLogs(LogPaginationParams @params)
        {
            var result = _unit.LogRepository.GetLogs(l=> true , @params.PageNumber, @params.PageSize);
            if (result is null)
                return CustomResult<PaginationResult<Log>>.Failure(CustomError.NotFound(new List<string> { "No logs found" }));
            return CustomResult<PaginationResult<Log>>.Success(result); 
        }
    }
}
