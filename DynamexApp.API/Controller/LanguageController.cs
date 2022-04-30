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
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService categoryService)
        {
            _languageService = categoryService;
        }
        [HttpPost("")]
        public async Task<IActionResult> Create(LanguagePostDTO languagePost)
        {
            try
            {
                await _languageService.CreateAsync(languagePost);
            }
            catch (RecordAlreadyExistException msg)
            {
                return Conflict(msg.Message);
            }
            
            return StatusCode(201);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            LanguageGetDTO model = null;

            try
            {
                model = await _languageService.GetLanguageAsync(id);
            }
            catch (ItemNotFoundException ex)
            {

                return NotFound(ex.Message);
            }

            return Ok(model);
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<LanguageListDTO> languageGets =await _languageService.GetAllLanguagesAsync(x => x.IsDeleted == false);
            
           return Ok(languageGets);
        }
    
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, LanguagePostDTO languagePostDTO)
        {
            try
            {
                await _languageService.EditAsync(id, languagePostDTO);
            }
            catch (ItemNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch(RecordAlreadyExistException ex)
            {
                return Conflict(ex.Message);
            }
            return NoContent();
        }
        //public void Delete(int id)
        //{
        //    try
        //    {
        //        _languageService.Delete(id);
        //    }
        //    catch (ItemNotFoundException ex)
        //    {
        //       true NotFound(ex.Message);
        //    }
            
        //}



    }
}
