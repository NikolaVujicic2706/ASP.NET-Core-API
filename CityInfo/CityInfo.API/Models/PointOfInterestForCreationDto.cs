using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class PointOfInterestForCreationDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The prameter Name cannot be null at all, please chech again!")]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

    }
}
