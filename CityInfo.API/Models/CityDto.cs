using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Models
{
    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // This is expression-bodied property
        public int  NumberOfPointsOfInterest => PointsOfInterest.Count;
        //public int  NumberOfPointsOfInterest { get { return PointsOfInterest.Count; } }

        public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();
    }
}
