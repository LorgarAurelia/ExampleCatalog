using TestCatalogue.Database.SQLModels;
using TestCatalogue.DTO;

namespace TestCatalogue.WebSiteService
{
    public interface ICatalogueService
    {
        Task<Responce<string>> CreateCategory(CategoryCreationForm category);
        Task<Responce<string>> CreateGoods(GoodsCreationForm goodsData);
        Task<Responce<GoodsCreationForm>> CreateGoodsForm(int categoryId);
        Task<Responce<string>> DeleteCategory(int categoryId);
        Task<Responce<Category>> ShowAllCategories();
        Task<Responce<Good>> ShowAllGoods(int categoryId = 0);
        Task<Responce<GoodsDetails>> ShowFullGoodsData(int goodsId);
    }
}