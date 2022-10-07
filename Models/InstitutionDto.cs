using System.Collections.Generic;

namespace eUrzad.Models
{
    public class InstitutionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string OpeningHours { get; set; }
        public string ContactEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string Voicodeship { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string BuldingNumber { get; set; }
        public string ApartmentNumber { get; set; }

        public virtual List<EmployeeDto> Employees { get; set; }
        public virtual List<CustomerDto> Customers { get; set; }
        public virtual List<DocumentTypeDto> DocumentTypes { get; set; }
    }
}
