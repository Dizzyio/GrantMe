namespace Grant_Me.Models // Namespace matches the folder structure
{
    public class Grant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EligibilityCriteria { get; set; }
        public decimal Amount { get; set; }
    }
}
