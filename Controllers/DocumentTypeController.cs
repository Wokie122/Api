using eUrzad.Models;
using eUrzad.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eUrzad.Controllers
{
    [Route("api/institution/{institutionId}/documentType")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeService _documentTypeService;

        public DocumentTypeController(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }

        [HttpPost]
        public ActionResult Post([FromRoute] int institutionId, [FromBody] CreateDocumentTypeDto dto)
        {
            var newDocumentId = _documentTypeService.Create(institutionId, dto);

            return Created($"api/institution/{institutionId}/documenttype/{newDocumentId}", null);
        }

        [HttpGet("{documentTypeId}")]
        public ActionResult<DocumentTypeDto> Get([FromRoute] int institutionId, [FromRoute] int documentTypeId)
        {
            DocumentTypeDto document = _documentTypeService.GetById(institutionId, documentTypeId);
            return Ok(document);
        }

        [HttpGet]
        public ActionResult<List<DocumentTypeDto>> Get([FromRoute] int institutionId)
        {
            var result = _documentTypeService.GetAll(institutionId);
            return Ok(result);
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute] int institutionId)
        {
            _documentTypeService.RemoveAll(institutionId);

            return NoContent();
        }

        [HttpDelete("{documentTypeId}")]
        public ActionResult Delete([FromRoute] int institutionId, [FromRoute] int documentTypeId)
        {
            _documentTypeService.RemoveById(institutionId, documentTypeId);

            return NoContent();
        }

        [HttpPut("{documentTypeId}")]
        public ActionResult Update([FromBody] UpdateDocumentTypeDto dto, [FromRoute] int institutionId, [FromRoute] int documentTypeId)
        {
            _documentTypeService.Update(dto, institutionId, documentTypeId);

            return Ok();
        }
    }
}
