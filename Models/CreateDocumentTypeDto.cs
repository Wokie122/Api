using System.ComponentModel.DataAnnotations;

namespace eUrzad.Models
{
    public class CreateDocumentTypeDto
    {
        [Required]
        public string Name { get; set; }

        public int InstitutionId { get; set; }
    }
}
