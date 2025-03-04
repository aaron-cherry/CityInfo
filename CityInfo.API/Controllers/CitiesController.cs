﻿using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id)
        {
            var returnedCity = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            
            if (returnedCity == null)
            {
                //var response = new { info = "woopsies" };
                //return NotFound(response);
                return NotFound();
            }
            return Ok(returnedCity);
        }
    }
}
