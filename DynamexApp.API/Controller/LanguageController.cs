﻿using DynamexApp.Business.DTOs.LanguageDTO;
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
            await _languageService.CreateAsync(languagePost);
            return StatusCode(201);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _languageService.GetLanguageAsync(id));
        }
        
    }
}
