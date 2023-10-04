using Microsoft.EntityFrameworkCore;
using System.Drawing;
using ClincApi.Models;
namespace ClincApi.Repositeries
{
    public class CategoryRepo : ICategoryRepo
    {
        ClinicDBContext _CategoryDbContext;
        public CategoryRepo(ClinicDBContext CategoryDbContext)
        {
            _CategoryDbContext = CategoryDbContext;
        }
        public List<Category> GetAllCategories()
        {
            return _CategoryDbContext.Categories.Include(x => x.AppUser).ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _CategoryDbContext.Categories.Include(x => x.AppUser).Where(x => x.Id == id).SingleOrDefault();
        }

        public Category addCategory(Category category)
        {
            _CategoryDbContext.Categories.Add(category);
            _CategoryDbContext.SaveChanges();
            return category;
        }

        public void UpdateCategory(Category category)
        {
            _CategoryDbContext.Entry(category).State = EntityState.Modified;
            _CategoryDbContext.SaveChanges();
        }

        public void deleteCategory(int id)
        {
            Category category = _CategoryDbContext.Categories.Find(id);
            _CategoryDbContext.Remove(category);
            _CategoryDbContext.SaveChanges();
        }
    }
}
