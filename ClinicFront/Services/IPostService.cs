using ClinicModels;

namespace ClinicFront.Services
{
    public interface IPostService
    {
        Task<HttpResponseMessage> AddPost(PostDTO postDTO);
        Task<HttpResponseMessage> DeletePost(int id);
        Task<List<PostDTO>> getallPosts(string id,int page);
        Task<PostDTO> getbyid(int id);
        Task<HttpResponseMessage> UpdatePost(PostDTO postDTO);
    }
}