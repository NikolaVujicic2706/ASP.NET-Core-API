using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controlers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesControlers : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
            
        }

        [HttpGet("{id}")]
        public IActionResult GetCities(int id)
        {
            var cityToReturn =  (CitiesDataStore.Current.Cities).FirstOrDefault(x => x.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);
            //return new JsonResult((CitiesDataStore.Current.Cities).FirstOrDefault(x => x.Id == id));
            
        }
    }
}
