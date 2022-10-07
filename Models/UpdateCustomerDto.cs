using System.ComponentModel.DataAnnotations;

namespace eUrzad.Models
{
    public class UpdateCustomerDto
    {
        [Required]
        public string Name { get; set; }
        public string SecoundName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public byte Age { get; set; }
        public string Pesel { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [Required]
        public string ContactEmail { get; set; }
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
