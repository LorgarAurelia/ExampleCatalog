using TestCatalogue.Database.Models;

namespace TestCatalogue.Database
{
    public interface IExampleRepository
    {
        void AddGoods(Goods goodsTitle, GoodsContent content);
        void AddCategory(Category category);
        void DeleteCategory(int categoryId);
        void DeleteGoods(int goodsId);
        List<Category> GetCategories();
        GoodsContent GetContent(int goodsId);
        List<Goods> GetGoods();
        void AddSpecification(GoodsSpecification specification, int goodsId);
    }
}