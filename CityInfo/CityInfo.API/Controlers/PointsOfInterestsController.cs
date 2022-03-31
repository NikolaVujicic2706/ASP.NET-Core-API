using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controlers
{
    [ApiController]
    [Route("api/cities/{cityId}/pointsOfInterest")]
    public class PointsOfInterestsController : ControllerBase
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

        [HttpGet("{id}", Name = "GetPointOfInterest")]

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

        [HttpPost]
        public IActionResult CreatePointOfInterest(int cityId,
            [FromBody] PointOfInterestForCreationDto pointOfInterest)
        {


            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }


            // demo purposes - to be improved
            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(
                             c => c.PointsOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute(
               "GetPointOfInterest",
               new { cityId, id = finalPointOfInterest.Id },
               finalPointOfInterest);
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id)
        {
            var city = CitiesDataStore.Current.Cities
                .FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointsOfInterest
                .FirstOrDefault(c => c.Id == id);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            city.PointsOfInterest.Remove(pointOfInterestFromStore);

            return NoContent();

        }

    }
}
