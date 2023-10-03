using ClincApi.Models;
using Microsoft.AspNetCore.Identity;

namespace ClincApi.Repositeries
{
    public interface IAppUserRepo
    {
        Task<IdentityResult> AddRoleToUser(AppUser user, string password, string rolename);
        Task<IdentityResult> DeleteUser(AppUser user);
        Task<List<AppUser>> Getalladmin();
        List<AppUser> Getallusers();
        Task<AppUser> GetUserByEmail(string email);
        Task<AppUser> GetuserbyIdAsync(string id);
        Task<IList<string>> GetUserRoles(AppUser user);
        Task<string> JWT();
        Task<bool> Logincheck(string password, string Email);
        void Update(AppUser user);
    }
}