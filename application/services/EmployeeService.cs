using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using application.interfaces;
using domain.entities;
using domain.utilities.results.implementations;
using domain.utilities.results.interfaces;
using infrastracture.persistance.repositories.dapper.employee;

namespace application.services
{
    public class EmployeeService : IEmployeeService
    {
        IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IDataResult<IEnumerable<Employee>>> GetAllEmployeeAsync()
        {
            string query = """
                select 
                COMPANY_ID,
                EMP_NO,
                FNAME,
                LNAME,
                PICTURE_ID,
                DATE_OF_BIRTH,
                SEX,
                BLOOD_TYPE,
                EMPLOYEE_STATUS,
                DATE_OF_EMPLOYMENT,
                CASE
                WHEN DATE_OF_LEAVING > TO_CHAR(SYSDATE,'yyyy.MM.dd')
                    THEN null
                    ELSE DATE_OF_LEAVING
                END AS DATE_OF_LEAVING
                from vw_meyer_set_sicil
            """;
            
            var result = await _employeeRepository.GetAllAsync(query);
            return new SuccessDataResult<IEnumerable<Employee>>(result);
        }
    }
}