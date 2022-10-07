using eUrzad.Models;
using eUrzad.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eUrzad.Controllers
{
    [Route("api/institution")]
    [ApiController]
    public class InstitutionController : ControllerBase
    {
        private readonly IInstitutionService _institutionService;

        public InstitutionController(IInstitutionService institutionService)
        {
            _institutionService = institutionService;
        }

        [HttpPost]
        public ActionResult CreateInstytucje([FromBody] CreateInstitutionDto dto)
        {
            var id = _institutionService.Create(dto);

            return Created($"/api/institution/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<InstitutionDto>> GetAll()
        {
            var institutionsDtos = _institutionService.GetAll();

            return Ok(institutionsDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<InstitutionDto> Get([FromRoute] int id)
        {
            var institution = _institutionService.GetById(id);

            return Ok(institution);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _institutionService.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateInstitutionDto dto, [FromRoute] int id)
        {
            _institutionService.Update(dto, id);

            return Ok();
        }
    }
}
