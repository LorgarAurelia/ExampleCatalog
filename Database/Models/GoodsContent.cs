namespace TestCatalogue.Database.Models
{
    public class GoodsContent
    {
        public int Id { get; set; }
        public int GoodsId { get; set; }
        public string Description { get; set; }
        public List<GoodsSpecification> Specifications { get; set; }
    }
}
