using eUrzad.Models;
using eUrzad.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eUrzad.Controllers
{
    [Route("api/institution/{institutionId}/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int institutionId, [FromBody] CreateCustomerDto dto)
        {
            var newCustomerId = _customerService.Create(institutionId, dto);

            return Created($"api/institution/{institutionId}/customer/{newCustomerId}", null);
        }

        [HttpGet("{customerId}")]
        public ActionResult<CustomerDto> Get([FromRoute] int institutionId, [FromRoute] int customerId)
        {
            CustomerDto customer = _customerService.GetById(institutionId, customerId);
            return Ok(customer);
        }

        [HttpGet]
        public ActionResult<List<CustomerDto>> Get([FromRoute] int institutionId)
        {
            var result = _customerService.GetAll(institutionId);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute] int institutionId)
        {
            _customerService.RemoveAll(institutionId);

            return NoContent();
        }

        [HttpDelete("{customerId}")]
        public ActionResult Delete([FromRoute] int institutionId, [FromRoute] int customerId)
        {
            _customerService.RemoveById(institutionId, customerId);

            return NoContent();
        }

        [HttpPut("{customerId}")]
        public ActionResult Update([FromBody] UpdateCustomerDto dto, [FromRoute] int institutionId, [FromRoute] int customerId)
        {
            _customerService.Update(dto, institutionId, customerId);

            return Ok();
        }
    }
}
