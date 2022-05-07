using DynamexApp.Business.HelperService.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamexApp.Business.HelperService.Implementations
{
     public class HelperAccessor : IHelperAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HelperAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string BaseUrl => $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}";
    }
}
