using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sortech_Assignment.Application.Dtos.LogDtos;
using Sortech_Assignment.Application.IServices;

namespace Sortech_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogServices _logServices;
        public LogsController(ILogServices logServices)
        {
            _logServices = logServices;
        }
        [HttpGet("blocked-attempts")]
        public async Task<IActionResult> GetBlockedAttempts([FromQuery] LogPaginationParams @params)
        {
            var result = await _logServices.GetAllLogs(@params);
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
