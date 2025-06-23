using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class employeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public employeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        [HttpGet("getall-employee")]
        public async Task<IActionResult> GetAllEmployeeAsync()
        {
            var result = await _employeeService.GetAllEmployeeAsync();
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}