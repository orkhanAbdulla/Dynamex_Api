using DynamexApp.Business.DTOs;
using DynamexApp.Business.DTOs.BrandDto;
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
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm]BrandPostDto brandPostDto)
        {
          
            BrandReturnDto brandReturnDto = await _brandService.CreateAsync(brandPostDto);
            return StatusCode(201,brandReturnDto);
        }
        [HttpGet("{countryId}")]
        public async Task<IActionResult> GetAll(int countryId)
        {
            IEnumerable<BrandGetDTO> brandGetDTO = await _brandService.GetAllBrandAsync(countryId);
            return Ok(brandGetDTO);
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll(string search,int page=1)
        {
            PagenetedListDTO<BrandListItemDto> pagenetedListDTO = await _brandService.GetAllFiltred(page, search);
            return Ok(pagenetedListDTO);
        }
    }
}
