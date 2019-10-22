using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_ADO_DotNet.Models.BO;

namespace WebApi_ADO_DotNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        #region Declaration
        Employee _oEmployee = new Employee();
        List<Employee> _oEmployees = new List<Employee>();
        #endregion


        //[Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            List<Employee> _oEmployees = new List<Employee>();
            Employee oEmployee = new Employee();
            _oEmployees = Employee.Gets();
            return _oEmployees.ToList();
        }
    }
}