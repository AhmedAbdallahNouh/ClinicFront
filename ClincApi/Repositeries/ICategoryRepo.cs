using ClincApi.Models;

namespace ClincApi.Repositeries
{
    public interface ICategoryRepo
    {
        Category addCategory(Category category);
        void deleteCategory(int id);
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void UpdateCategory(Category category);
    }
}