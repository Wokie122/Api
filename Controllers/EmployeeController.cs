using eUrzad.Models;
using eUrzad.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eUrzad.Controllers
{
    [Route("api/institution/{institutionId}/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int institutionId, [FromBody] CreateEmployeeDto dto)
        {
            var newEmployeeId = _employeeService.Create(institutionId, dto);

            return Created($"api/institution/{institutionId}/employee/{newEmployeeId}", null);
        }

        [HttpGet("{employeeId}")]
        public ActionResult<EmployeeDto> Get([FromRoute] int institutionId, [FromRoute] int employeeId)
        {
            EmployeeDto employee = _employeeService.GetById(institutionId, employeeId);
            return Ok(employee);
        }

        [HttpGet]
        public ActionResult<List<EmployeeDto>> Get([FromRoute] int institutionId)
        {
            var result = _employeeService.GetAll(institutionId);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute] int institutionId)
        {
            _employeeService.RemoveAll(institutionId);

            return NoContent();
        }

        [HttpDelete("{employeeId}")]
        public ActionResult Delete([FromRoute] int institutionId, [FromRoute] int employeeId)
        {
            _employeeService.RemoveById(institutionId, employeeId);

            return NoContent();
        }

        [HttpPut("{employeeId}")]
        public ActionResult Update([FromBody] UpdateEmployeeDto dto, [FromRoute] int institutionId, [FromRoute] int employeeId)
        {
            _employeeService.Update(dto, institutionId, employeeId);

            return Ok();
        }
    }
}
