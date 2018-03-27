using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    // Both of these works. 1 is rekomended for api's 2 for webapp
    [Route("api/cities")]
    //[Route("api/[controller]")]
    public class CitiesController : Controller
    {
        private readonly ICityInfoRepository _cityInfoRepository;

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }
        [HttpGet]
        public IActionResult GetCities()
        {
            var cityEntities = _cityInfoRepository.GetCities();
            var result = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCities(int id, bool includePointOfInterest)
        {
            var city = _cityInfoRepository.GetCity(id, includePointOfInterest);
            if (city == null)
            {
                return NotFound();
            }

            if (includePointOfInterest)
            {
                var result = Mapper.Map<CityDto>(city);
                return Ok(result);
            }

            var res = Mapper.Map<CityWithoutPointsOfInterestDto>(city);
            return Ok(res);
        }
    }
}
