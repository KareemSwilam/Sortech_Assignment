using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Sortech_Assignment.Application.IServices;

namespace Sortech_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryServices _country;
        public CountriesController(ICountryServices country)
        {
            _country = country;
        }
        [HttpPost("block/{countryCode}")]
        public async Task<IActionResult> BlockCountry(string countryCode)
        {
            var result = await _country.AddBlockedCoutry(countryCode);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpDelete("block/{countryCode}")]
        public async Task<IActionResult> UnBlockCountry(string countryCode)
        {
            var result = await _country.RemoveBlockedCoutry(countryCode);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpGet("blocked")]
        public async Task<IActionResult> GetBlockedCountries()
        {
            var result = await _country.GetAllCountry();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
    }
}
