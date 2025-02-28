namespace Grant_Me.Models // Namespace matches the folder structure
{
    public class Grant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string EligibilityCriteria { get; set; }
        public decimal Amount { get; set; }
    }
}
