using TestCatalogue.Database;
using TestCatalogue.Database.Models;
using TestCatalogue.DTO;
using TestCatalogue.Exceptions;

namespace TestCatalogue.WebSiteService
{
    public class CatalogueService : ICatalogueService
    {
        private IRepository _repo;
        public CatalogueService(IRepository repository)
        {
            _repo = repository;
        }

        public Responce<Category> ShowAllCategories() => new() { Body = _repo.GetCategories() };
        public Responce<string> CreateCategory(CategoryCreationForm category)
        {
            _repo.AddCategory(new() { Name = category.CategoryName, SpecificationsFields = category.CategoryFields.ToList() });
            return new() { Body = new() { "Ok" } };
        }
        public Responce<string> DeleteCategory(int categoryId)
        {
            try
            {
                _repo.DeleteCategory(categoryId);
                return new() { Body = new() { "Ok" } };
            }
            catch (NullResultException ex)
            {
                return new() { Body = new() { ex.Message } };
            }
        }
        public Responce<GoodsCreationForm> CreateGoodsForm(int categoryId)
        {
            var fieldInCategory = _repo.GetCategories().Where(c => c.Id == categoryId).First().SpecificationsFields;

            GoodsCreationForm form = new()
            {
                CategoryId = categoryId
            };

            foreach (var field in fieldInCategory)
            {
                form.Specifications.Add(new() { Name = field, Content = "Enter your text here" });
            }

            return new() { Body = new() { form } };
        }

        public Responce<string> CreateGoods(GoodsCreationForm goodsData)
        {
            Goods goodsTitle = new()
            {
                CategoryId = goodsData.CategoryId,
                Name = goodsData.Name,
                Cost = goodsData.Cost
            };
            GoodsContent content = new()
            {
                Description = goodsData.Description,
                Specifications = goodsData.Specifications
            };

            _repo.AddGoods(goodsTitle, content);

            return new() { Body = new() { "Ok" } };
        }

        public Responce<Goods> ShowAllGoods(int categoryId = 0)
        {
            if (categoryId == 0)
                return new() { Body = _repo.GetGoods() };
            else
            {
                var goodsPerCategory = _repo.GetGoods().Where(g => g.CategoryId == categoryId).ToList();
                return new() { Body = goodsPerCategory };
            }
        }
        public Responce<GoodsContent> ShowFullGoodsData(int goodsId)
        {
            var goodsData = _repo.GetContent(goodsId);
            return new() { Body = new() { goodsData } };
        }
    }
}
