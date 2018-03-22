using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class PointOfInterestForUpdateDto
    {
        //There is something called fluent validation, that lets us validate in a better way.
        // Here we have to validate some cases with annotation and other cases in code in the controler
        [Required(ErrorMessage = "You must provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
