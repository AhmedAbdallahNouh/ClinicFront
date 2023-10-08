using ClinicModels;

namespace ClinicFront.Services
{
    public interface ICategoryService
    {
        Task<HttpResponseMessage> Addcategory(CategoryDTO category);
        Task Deletecategory(int id);
        Task<List<CategoryDTO>> getallcategory();
        void Updatecategory(CategoryDTO categoryDTO);
    }
}