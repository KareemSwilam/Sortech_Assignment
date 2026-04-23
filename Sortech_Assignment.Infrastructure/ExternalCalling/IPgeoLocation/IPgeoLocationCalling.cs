using Microsoft.Extensions.Options;
using Sortech_Assignment.Application.IServices;
using Sortech_Assignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Infrastructure.ExternalCalling.IPgeoLocation
{
    public class IPgeoLocationCalling : ILocationServices
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<IPgeoLocationSetting> _settings;
        public IPgeoLocationCalling(HttpClient httpClient, IOptions<IPgeoLocationSetting> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
        }
        public async Task<Country> GetCountryByCode(string code)
        {
            var url = $"https://restcountries.com/v3.1/alpha/{code}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<APIResponse>();
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

    }
}




