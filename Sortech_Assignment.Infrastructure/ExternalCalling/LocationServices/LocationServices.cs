using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Sortech_Assignment.Application.Dtos.CountryDtos;
using Sortech_Assignment.Application.IServices;
using Sortech_Assignment.Domain.Models;
using Sortech_Assignment.Infrastructure.ExternalCalling.LocationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Infrastructure.ExternalCalling.IPgeoLocation
{
    public class LocationServices : ILocationServices
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<IPgeoLocationSetting> _settings;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LocationServices(HttpClient httpClient, IOptions<IPgeoLocationSetting> settings, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _settings = settings;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<Country> GetCountryByCode(string code)
        {
            var url = $"https://restcountries.com/v3.1/alpha/{code}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<RestCountriesResponse>();
                var country = new Country
                {
                    Cca2 = result[0].cca2,
                    Cca3 = result[0].cca3,
                    OfficialName = result[0].name.official,
                    CommenName = result[0].name.common,
                    PostalCodeFormat = result[0].postalCode.format,
                    CapitalLatitude = result[0].capitalInfo.latlng[0],
                    CapitalLongitude = result[0].capitalInfo.latlng[1]
                };
                return country;
            }
            else
                return null;    
        }

        public async Task<GetCountryByIPResponseDto> GetCountryByIPAdress(string? ipAddress = null)
        {
            var url = $"{_settings.Value.BaseUrl}?apiKey={_settings.Value.Key}";
            
            if (!string.IsNullOrEmpty(ipAddress))
                url += $"&ip={ipAddress}";
            else
            {
                ipAddress = await GetUserIPAdress();
                url += $"&ip={ipAddress}";  
            }
            var response = await _httpClient.GetAsync(url);
            var userAgent = _httpContextAccessor.HttpContext?.Request.Headers["User-Agent"].ToString();
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<IPgeoLocationResponse>();
                var dto = new GetCountryByIPResponseDto
                {
                    IP = ipAddress,
                    UserAgent = userAgent,
                    Country = new Country
                    {
                        Cca2 = result.location.country_code2,
                        Cca3 = result.location.country_code3,
                        CommenName = result.location.country_name,
                        OfficialName = result.location.country_name_official
                    }
                };
                return dto;
            }
            return null;
        }
        private async Task<string> GetUserIPAdress()
        {
            var ipAddress = _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
            if (ipAddress == "::1" || ipAddress == "127.0.0.1")
            {
                var response = await _httpClient.GetAsync("https://api.ipify.org?format=json");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadFromJsonAsync<IpifyResponse>();
                    ipAddress = result.ip;
                }
            }
            return ipAddress;
        }


    }
}




