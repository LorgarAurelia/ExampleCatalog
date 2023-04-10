using TestCatalogue.Database.SQLModels;

namespace TestCatalogue.DTO
{
    public class GoodsDetails
    {
        public string  Description { get; set; }
        public List<GoodsSpecifications> Specifications { get; set; }
        public GoodsDetails(List<Specification> specification, GoodsContent content)
        {
            Specifications = new();
            foreach (var item in specification)
            {
                Specifications.Add(new() { Content = item.Content, Name = item.Name });
            }
            Description = content.Description;
        }
    }
}
