using System.ComponentModel.DataAnnotations;

namespace eUrzad.Models
{
    public class UpdateInstitutionDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string OpeningHours { get; set; }
        [EmailAddress]
        public string ContactEmail { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string Voicodeship { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string BuldingNumber { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
