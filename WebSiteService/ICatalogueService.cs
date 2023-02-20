using TestCatalogue.Database.Models;
using TestCatalogue.DTO;

namespace TestCatalogue.WebSiteService
{
    public interface ICatalogueService
    {
        Responce<string> CreateCategory(CategoryCreationForm category);
        Responce<string> CreateGoods(GoodsCreationForm goodsData);
        Responce<GoodsCreationForm> CreateGoodsForm(int categoryId);
        Responce<string> DeleteCategory(int categoryId);
        Responce<Category> ShowAllCategories();
        Responce<Goods> ShowAllGoods(int categoryId = 0);
        Responce<GoodsContent> ShowFullGoodsData(int goodsId);
    }
}