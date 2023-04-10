using Microsoft.EntityFrameworkCore;
using TestCatalogue.Database.SQLModels;
using TestCatalogue.Exceptions;

namespace TestCatalogue.Database
{
    public class Repository : IRepository
    {
        public async Task AddCategory(Category category, List<CategorySpecificationsField> specifications)
        {
            using PortfolioRepositoryContext context = new();
            context.Categories.Add(category);
            await context.SaveChangesAsync();
            category = context.Categories.OrderBy(c => c.Id).Last();

            foreach (var specification in specifications) 
            {
                specification.CategoryId = category.Id;
                context.CategorySpecificationsFields.Add(specification);
            }
            await context.SaveChangesAsync();
        }

        public async Task AddGoods(Good goodsTitle, GoodsContent content, List<Specification> specifications)
        {
            using PortfolioRepositoryContext context = new();

            context.GoodsContents.Add(content);
            await context.SaveChangesAsync();
            content = context.GoodsContents.OrderBy(c => c.Id).Last();

            foreach (var specification in specifications)
            {
                specification.ContentId = content.Id;
                context.Specifications.Add(specification);
            }
            
            goodsTitle.ContentId = content.Id;
            context.Goods.Add(goodsTitle);
            await context.SaveChangesAsync();
        }

        public async Task AddCategorySpecifications(CategorySpecificationsField specification)
        {
            using PortfolioRepositoryContext context = new();
            context.CategorySpecificationsFields.Add(specification);
            await context.SaveChangesAsync();
        }

        public async Task DeleteCategory(int categoryId)
        {
            using PortfolioRepositoryContext context = new();

            var categoryToDelete = context.Categories.Where(cat => cat.Id == categoryId).FirstOrDefault() ?? throw new NullResultException();
            var fieldsToDelete = context.CategorySpecificationsFields.Where(f => f.CategoryId == categoryId).ToArray() ?? throw new NullResultException();

            foreach (var item in fieldsToDelete)
                context.CategorySpecificationsFields.Remove(item);
            
            context.Categories.Remove(categoryToDelete);
            await context.SaveChangesAsync();
        }

        public async Task DeleteGoods(int goodsId)
        {
            using PortfolioRepositoryContext context = new();

            var goodToDelete = context.Goods.Where(g => g.Id == goodsId).FirstOrDefault() ?? throw new NullResultException();
            await context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetCategories()
        {
            using PortfolioRepositoryContext context = new();
            return await context.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<GoodsContent> GetContent(int goodsId)
        {
            using PortfolioRepositoryContext context = new();
            var goods = context.Goods.Where(g => g.Id == goodsId).FirstOrDefault() ?? throw new NullResultException();
            return await context.GoodsContents.AsNoTracking().Where(gc => gc.Id == goods.ContentId).FirstAsync();
        }

        public async Task<List<Good>> GetGoods()
        {
            using PortfolioRepositoryContext context = new();
            return await context.Goods.AsNoTracking().ToListAsync();
        }

        public async Task<Good> GetGoodById(int categoryId)
        {
            using PortfolioRepositoryContext context = new();
            return await context.Goods.AsNoTracking().Where(g => g.CategoryId == categoryId).FirstOrDefaultAsync() ??throw new NullResultException();
        }

        public async Task<List<CategorySpecificationsField>> GetCategoryFields(int categoryId)
        {
            using PortfolioRepositoryContext context = new();
            return await context.CategorySpecificationsFields.AsNoTracking().Where(f => f.CategoryId == categoryId).ToListAsync();
        }

        public async Task<List<Specification>> GetSpecifications(int contentId)
        {
            using PortfolioRepositoryContext context = new();
            return await context.Specifications.AsNoTracking().Where(s => s.ContentId == contentId).ToListAsync();
        }
    }
}
