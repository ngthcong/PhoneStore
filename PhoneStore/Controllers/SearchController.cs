using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneStore.Interfaces.Services;

namespace PhoneStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet("{query}")]
        public IActionResult Search( string query)
        {
            
           bool isNumber =  double.TryParse(query, out double n);
            if (isNumber)
            {
                return Ok(_searchService.GetProductsByPrice(n));
            }
            return Ok(_searchService.GetProductsByName(query));
        }
    }
}
