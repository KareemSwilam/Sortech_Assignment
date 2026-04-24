using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sortech_Assignment.Application.Dtos.CountryDtos;
using Sortech_Assignment.Application.IServices;
using Sortech_Assignment.Application.Validation;

namespace Sortech_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPController : ControllerBase
    {
        private readonly ICountryServices _countryServices;
        public IPController(ICountryServices countryServices)
        {
            _countryServices = countryServices;
        }
        [HttpGet("lookup")]
        [ServiceFilter(typeof(ValidationFilter<IPLockupDto>))]
        public async Task<IActionResult> LookUp([FromQuery]IPLockupDto dto)
        {
            var result = await _countryServices.GetCountryByIPAdress(dto.IPAddress);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet("check-block")]
        public async Task<IActionResult> CheckBlock()
        {
            var result = await _countryServices.CheckBlock();
            if (result.IsSuccess)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
