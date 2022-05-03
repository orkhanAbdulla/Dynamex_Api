using DynamexApp.Business.DTOs.CountryDTO;
using DynamexApp.Business.Services.Implementations;
using DynamexApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamexApp.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody]List<CountryPostDTO> countryPostDTOs)
        {
            foreach (var country in countryPostDTOs)
            {
                await _countryService.CreateAsync(country);
            }
            
            return StatusCode(201);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            CountryGetDto countryGetDto = await _countryService.GetCountryAsync(id);
            return Ok(countryGetDto);
        }
        [HttpGet("get/{languageCode}")]
        public async Task<IActionResult> GetAll(string languageCode)
        {
            IEnumerable<CountryGetDto> countryGetDtos = await _countryService.GetAllCountryAsync(languageCode);
            return Ok(countryGetDtos);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CountryEditDTO countryPostDTO)
        {
            await _countryService.EditAsync(id,countryPostDTO);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _countryService.Delete(id);
            return NoContent();
        }
    }
}
