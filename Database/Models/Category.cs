namespace TestCatalogue.Database.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string>? SpecificationsFields { get; set; }
    }
}
