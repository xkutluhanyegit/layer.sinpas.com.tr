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
        private readonly IMeyerGetTokenService _meyerGetTokenService;
        private readonly IEmployeeService _employeeService;
        private readonly IMeyerSetSicilService _meyerSetSicilService;
        
        public meyer(IMeyerGetTokenService meyerGetTokenService,IEmployeeService employeeService,IMeyerSetSicilService meyerSetSicilService)
        {
            _meyerGetTokenService = meyerGetTokenService;
            _employeeService = employeeService;
            _meyerSetSicilService = meyerSetSicilService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var token = await _meyerGetTokenService.GetTokenAsync();
            var employee = await _employeeService.GetAllEmployeeAsync();
            var setSicil = await _meyerSetSicilService.MeyerSetSicilAsync();
            if (employee.Success)
            {
                
            }
            
            return Ok(token);
        }
    }
}