using EmployeeManagmentService.Data.Models;
using EmployeeManagmentService.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IRepository<Position> _positionRepository;
        public PositionController(IRepository<Position> positionRepository)
        {
            _positionRepository = positionRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var positions = _positionRepository.Get().ToList();
                return Ok(positions);
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
                var position = _positionRepository.Get(id);
                if(position == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(position);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }

        [HttpPost]
        public IActionResult Post(Position position)
        {
            try
            {
                _positionRepository.Add(position);
                return CreatedAtAction(nameof(Get), new { id = position.Id }, position);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}
