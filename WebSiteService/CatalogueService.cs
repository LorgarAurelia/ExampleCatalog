using TestCatalogue.Database;
using TestCatalogue.Database.SQLModels;
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

        public async Task<Responce<Category>> ShowAllCategories() => new() { Body = await _repo.GetCategories() };
        public async Task<Responce<string>> CreateCategory(CategoryCreationForm category)
        {
            await _repo.AddCategory(new() { Name = category.CategoryName}, category.ConvertToModels());

            return new() { Body = new() { "Ok" } };
        }
        public async Task<Responce<string>> DeleteCategory(int categoryId)
        {
            try
            {
                await _repo.DeleteCategory(categoryId);
                return new() { Body = new() { "Ok" } };
            }
            catch (NullResultException ex)
            {
                return new() { Body = new() { ex.Message } };
            }
        }
        public async Task<Responce<GoodsCreationForm>> CreateGoodsForm(int categoryId)
        {
            var fieldInCategory = _repo.GetCategoryFields(categoryId);

            GoodsCreationForm form = new()
            {
                CategoryId = categoryId
            };

            foreach (var field in await fieldInCategory)
            {
                form.Specifications.Add(new() { Name = field.Name, Content = "Enter your text here" });
            }

            return new() { Body = new() { form } };
        }

        public async Task<Responce<string>> CreateGoods(GoodsCreationForm goodsData)
        {
            Good goodsTitle = new()
            {
                CategoryId = goodsData.CategoryId,
                Name = goodsData.Name,
                Cost = goodsData.Cost
            };

            GoodsContent content = new()
            {
                Description = goodsData.Description
            };

            List<Specification> specifications = new();
            foreach (var specification in goodsData.Specifications)
            {
                specifications.Add(new() { Name = specification.Name, Content = specification.Content });
            }
            

            await _repo.AddGoods(goodsTitle, content,specifications);
            
            return new() { Body = new() { "Ok" } };
        }

        public async Task<Responce<Good>> ShowAllGoods(int categoryId = 0)
        {
            if (categoryId == 0)
                return new() { Body = await _repo.GetGoods() };
            else
                return new() { Body = { await _repo.GetGoodById(categoryId) } };
        }
        public async Task<Responce<GoodsDetails>> ShowFullGoodsData(int goodsId)
        {
            var goodsData = await _repo.GetContent(goodsId);
            var specifications = await _repo.GetSpecifications(goodsData.Id);

            return new() { Body = new() { new(specifications, goodsData) } };
        }
    }
}
