//using TestCatalogue.Database.Models;
//using TestCatalogue.Database.SQLModels;
//using TestCatalogue.Exceptions;

//namespace TestCatalogue.Database
//{
//    public class ExampleRepository : IRepository
//    {
//        private List<Category> _exampleOfCategories = new()
//        {
//            new() { Id = 1, Name = "RAM", SpecificationsFields = new()},
//            new() { Id = 2, Name = "Motherboard", SpecificationsFields = new()},
//            new() { Id = 3, Name = "CPU", SpecificationsFields = new()}
//        };
//        private List<Goods> _exampleOfGoods = new()
//        {
//            new() { Id = 1, CategoryId = 3, Name = "Ryzen 5 3600", Cost = 300m },
//            new() { Id = 2, CategoryId = 3, Name = "I5 10400f", Cost = 300m},
//            new() { Id = 3, CategoryId = 2, Name = "MSI B450A-PRO MAX", Cost = 200m},
//            new() { Id = 4, CategoryId = 2, Name = "MSI H510", Cost = 200m},
//            new() { Id = 5, CategoryId = 1, Name = "Kingston 8GB", Cost = 100m},
//            new() { Id = 6, CategoryId = 1, Name = "Corsair 8GB", Cost = 100m}
//        };
//        private List<GoodsContent> _exampleOfContents = new()
//        {
//            new() { Id = 1, GoodsId = 1, Description = "Example of Ryzen text", Specifications = new()},
//            new() { Id = 2, GoodsId = 2, Description = "Example of I5 text", Specifications = new()},
//            new() { Id = 3, GoodsId = 3, Description = "Example of B450", Specifications = new()},
//            new() { Id = 4, GoodsId = 4, Description = "Example of H510", Specifications = new()},
//            new() { Id = 5, GoodsId = 5, Description = "Example of Kingston", Specifications = new()},
//            new() { Id = 6, GoodsId = 6, Description = "Example of Corsair", Specifications = new()}
//        };

//        public List<Category> GetCategories() => _exampleOfCategories;
//        public void AddCategory(Category category)
//        {
//            category.Id = _exampleOfCategories.Count + 1;
//            _exampleOfCategories.Add(category);
//        }
//        public void DeleteCategory(int categoryId)
//        {
//            var categoryToDelete = _exampleOfCategories.Where(c => c.Id == categoryId).FirstOrDefault();

//            if (categoryToDelete == null)
//                throw new NullResultException();

//            _exampleOfCategories.Remove(categoryToDelete);
//        }

//        public List<Goods> GetGoods() => _exampleOfGoods;
//        public void DeleteGoods(int goodsId)
//        {
//            var goodsToDelete = _exampleOfGoods.Where(g => g.Id == goodsId).FirstOrDefault();
//            var goodsContent = _exampleOfContents.Where(c => c.GoodsId == goodsId).FirstOrDefault();

//            if (goodsContent == null || goodsToDelete == null)
//                throw new NullResultException();

//            _exampleOfGoods.Remove(goodsToDelete);
//            _exampleOfContents.Remove(goodsContent);
//        }
//        public void AddGoods(Goods goodsTitle, GoodsContent content)
//        {
//            goodsTitle.Id = _exampleOfGoods.Count + 1;
//            content.Id = _exampleOfContents.Count + 1;
//            content.GoodsId = goodsTitle.Id;

//            _exampleOfGoods.Add(goodsTitle);
//            _exampleOfContents.Add(content);
//        }
//        public GoodsContent GetContent(int goodsId)
//        {
//            var result = _exampleOfContents.Where(c => c.GoodsId == goodsId).FirstOrDefault();

//            if (result == null)
//                throw new NullResultException();

//            return result;
//        }
//        public void AddSpecification(GoodsSpecification specification, int goodsId)
//        {
//            foreach (var item in _exampleOfContents)
//            {
//                if(item.GoodsId == goodsId)
//                {
//                    item.Specifications.Add(specification);
//                    break;
//                }
//            }
//        }
//    }
//}
