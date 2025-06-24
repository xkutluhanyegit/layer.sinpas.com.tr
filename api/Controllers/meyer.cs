using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.interfaces;
using infrastracture.externalservices.meyerapi.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class meyer : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        
        public meyer(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            
            var employee = await _employeeService.GetAllEmployeeAsync();
            
            return Ok();
        }
    }
}