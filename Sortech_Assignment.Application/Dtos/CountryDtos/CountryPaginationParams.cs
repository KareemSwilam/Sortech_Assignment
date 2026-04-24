using Sortech_Assignment.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sortech_Assignment.Application.Dtos.CountryDtos
{
    public class CountryPaginationParams: PaginationParams
    {
        public string? Search { get; set; } 
    }
}
