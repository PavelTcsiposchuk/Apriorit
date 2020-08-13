using EmployeeManagmentService.Data.Models;
using EmployeeManagmentService.Data.Repositories.Interfaces;
using EmployeeManagmentService.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //var employees = _employeeRepository.Get(20, 0).Include(ep => ep.EmployeePositions).Where(c => c.EmployeePositions.Any(p => p.DateOfDissmisal == null)).ToList();

                var employees1 = _employeeRepository.Get(20, 0).Select(e => new EmployeeDto
                {
                    Name = e.Name,
                    Surname = e.Surname,
                    Salary = e.Salary,
                    //PositionName = _employeeRepository.GetLastPosition(e.Id).Position.PositionName,
                    //DateOfDissmisal = _employeeRepository.GetLastPosition(e.Id).DateOfDissmisal,
                    //HireDate = _employeeRepository.GetLastPosition(e.Id).HireDate

                }).ToList();
                // var e1 = _employeeRepository.Get().Include(e => e.Positions.Where(c => c.DateOfDissmisal == null));
                return Ok(employees1);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var employee = _employeeRepository.Get(id);
                if (employee == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(employee);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            try
            {
                _employeeRepository.Add(employee);
                return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
                
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
