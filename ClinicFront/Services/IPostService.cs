using ClinicModels;

namespace ClinicFront.Services
{
    public interface IPostService
    {
        Task<HttpResponseMessage> AddPost(PostDTO postDTO);
        Task DeletePost(int id);
        Task<List<PostDTO>> getallPosts();
        Task<PostDTO> getbyid(int id);
        void UpdatePost(PostDTO postDTO);
    }
}