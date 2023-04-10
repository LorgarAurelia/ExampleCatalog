using TestCatalogue.Database.SQLModels;

namespace TestCatalogue.Database
{
    public interface IRepository
    {
        Task AddGoods(Good goodsTitle, GoodsContent content, List<Specification> specifications);
        Task AddCategory(Category category, List<CategorySpecificationsField> specifications);
        Task DeleteCategory(int categoryId);
        Task DeleteGoods(int goodsId);
        Task<List<Category>> GetCategories();
        Task<GoodsContent> GetContent(int goodsId);
        Task<List<Good>> GetGoods();
        Task<Good> GetGoodById(int categoryId);
        Task<List<CategorySpecificationsField>> GetCategoryFields(int categoryId);
        Task<List<Specification>> GetSpecifications(int contentId);
        //Task AddCategorySpecifications(CategorySpecificationsField specification);
        //void AddSpecification(Specification specification, int goodsId);
    }
}