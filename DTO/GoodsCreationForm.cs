using TestCatalogue.Database.Models;

namespace TestCatalogue.DTO
{
    public class GoodsCreationForm
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }
        public List<GoodsSpecification> Specifications { get; set; }
        public GoodsCreationForm()
        {
            Specifications = new();
        }
    }
}
