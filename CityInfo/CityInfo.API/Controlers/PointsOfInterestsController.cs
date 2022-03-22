using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controlers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsOfInterest")]
    public class PointsOfInterestsController:ControllerBase
    {
        public IActionResult GetPointsOfInterest(int cityId)
        {
            var city = (CitiesDataStore.Current.Cities).FirstOrDefault(x => x.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(city.PointsOfInterest);
            }

        }

        [HttpGet("{id}")]

        public IActionResult GetPointOfInterest(int cityId, int id)
        {
            var city = (CitiesDataStore.Current.Cities).FirstOrDefault(x => x.Id == cityId);
            if (city != null)
            {
                var pointOfInterest = (city.PointsOfInterest).FirstOrDefault(x => x.Id == id);


                if (pointOfInterest == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(pointOfInterest);
                }
            }
            else
            {
                return NotFound();
            }
           


        }


    }
}
