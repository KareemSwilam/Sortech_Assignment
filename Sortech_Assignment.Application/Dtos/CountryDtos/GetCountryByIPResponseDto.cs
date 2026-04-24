using Sortech_Assignment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Application.Dtos.CountryDtos
{
    public class GetCountryByIPResponseDto
    {
        public string IP { get; set; }
        public string UserAgent { get; set; }   
        public Country Country { get; set; }
    }
}
