using DynamexApp.Business.CustomExceptions;
using DynamexApp.Business.DTOs.LanguageDTO;
using DynamexApp.Business.Services.Interfaces;
using DynamexApp.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamexApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        public LanguagesController(ILanguageService categoryService)
        {
            _languageService = categoryService;
        }
        [HttpPost("")]
        public async Task<IActionResult> Create(LanguagePostDTO languagePost)
        {
           await _languageService.CreateAsync(languagePost);
           return StatusCode(201);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            LanguageGetDTO model = await _languageService.GetLanguageAsync(id);
            return Ok(model);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
           IEnumerable<LanguageGetDTO> languageGets =await _languageService.GetAllLanguagesAsync(x => x.IsDeleted == false);
           return Ok(languageGets);
        }
    
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LanguagePostDTO languagePostDTO)
        {
            await _languageService.EditAsync(id, languagePostDTO);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _languageService.Delete(id);
           return NoContent();
        }



    }
}
