using ClinicModels;

namespace ClinicFront.Services
{
    public interface ICategoryService
    {
        Task<HttpResponseMessage> Addcategory(CategoryDTO category);
        Task<HttpResponseMessage> Deletecategory(int id);
        Task<List<CategoryDTO>> getallcategory();
        Task<List<CategoryDTO>> GetAllCategoryWithHisService();
        Task<List<CategoryDTO>> GetCategoriespagination();
        Task<HttpResponseMessage> Updatecategory(CategoryDTO categoryDTO);
    }
}