namespace eUrzad.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecoundName { get; set; }
        public string LastName { get; set; }
        public byte Age { get; set; }
        public string Pesel { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string Voicodeship { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string BuldingNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public string PasswordHash { get; set; }

        public int InstitutionId { get; set; }
        public virtual Institution Institution { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}