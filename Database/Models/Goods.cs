namespace TestCatalogue.Database.Models
{
    public class Goods
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
    }
}
