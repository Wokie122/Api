using System.ComponentModel.DataAnnotations;

namespace eUrzad.Models
{
    public class UpdateDocumentTypeDto
    {
        [Required]
        public string Name { get; set; }
    }
}
