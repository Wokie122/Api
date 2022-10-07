namespace eUrzad.Entities
{
    public class DocumentType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int InstitutionId { get; set; }
        public virtual Institution Institution { get; set; }
    }
}