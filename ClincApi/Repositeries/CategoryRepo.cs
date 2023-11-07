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
            return _CategoryDbContext.Categories.ToList();
        }

        public List<Category> GetAllCategoriesWithHisServices()
        {
            return _CategoryDbContext.Categories.Include(x => x.doctorServices).ToList();
        } 
        
        public List<Category> GetCategoriespagination()
        {
            var allcategories = _CategoryDbContext.Categories.ToList();
            var result = allcategories.Skip(0).Take(5).ToList();
            var total = _CategoryDbContext.Categories.Count();
            //var pages = (int)Math.Ceiling((decimal)total / 10);
            //double orderCafeTotalPrice = 0;

            return result;
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
