using ClincApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ClincApi.Repositeries
{
    public class AppUserRepo 
    {
        //ClinicDBContext _clinicDBContext;
        //private readonly UserManager<AppUser> _usermanger;
        //private readonly SignInManager<AppUser> _signmanger;

        //public AppUserRepo(ClinicDBContext clinicDBContext, UserManager<AppUser> usermanger, SignInManager<AppUser> signInManager)
        //{
        //    this._clinicDBContext = clinicDBContext;
        //    this._usermanger = usermanger;
        //    this._signmanger = signInManager;
        //}
        //public List<AppUser> Getallusers()
        //{
        //    //return usermanger.Users.ToList();
        //    return _clinicDBContext.Users.ToList();
        //}
        //public async Task<List<AppUser>> Getalladmin()
        //{
        //    return (List<AppUser>)await _usermanger.GetUsersInRoleAsync("admin");
        //}
        //public async Task<AppUser> GetuserbyIdAsync(string id)
        //{
        //    return await _usermanger.FindByIdAsync(id);
        //    //var user = this._clinicDBContext.Users.SingleOrDefault(u => u.Id == id);
        //}

        ////public async Task<IdentityResult> AddUser(AppUser user, string password)
        ////{
        ////    return await usermanger.CreateAsync(user, password);
        ////}

        //public async Task<IdentityResult> AddRoleToUser(AppUser user, string password, string rolename)
        //{
        //    IdentityResult Add_user_to_role = await _usermanger.AddToRoleAsync(user, rolename);
        //    return Add_user_to_role;
        //}

        //public async Task<IdentityResult> DeleteUser(AppUser user)
        //{
        //    return await _usermanger.DeleteAsync(user);
        //}

        //public async void Update(AppUser user)
        //{
        //    AppUser user1 = _clinicDBContext.Users.FirstOrDefault(u => u.Id == user.Id);

        //    user1.firstName = user.firstName;
        //    user1.LastName = user.LastName;
        //    user1.UserName = $"{user.firstName}{user.LastName}";
        //    user1.Age = user.Age;
        //    user1.Address = user.Address;
        //    user1.FaceBook = user.FaceBook;
        //    user1.WhatsUpNumber = user.WhatsUpNumber;
        //    user1.Instgram = user.Instgram;
        //    user1.LocationLat = user.LocationLat;
        //    user1.LocationLong = user.LocationLong;
        //    user1.Age = user.Age;
        //    user1.Email = user.Email;
        //    user1.PhoneNumber = user.PhoneNumber;
        //    _clinicDBContext.SaveChanges();
        //}

        //public async Task<bool> Logincheck(string password, string Email)
        //{
        //    AppUser checkemail = await _usermanger.FindByEmailAsync(Email);
        //    if (checkemail != null)
        //    {
        //        SignInResult result = await _signmanger.PasswordSignInAsync(checkemail, password, true, false);
        //        if (result.Succeeded == true)
        //        {
        //            return true;
        //        }
        //        return false;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        ////public async Task<bool> checkEmails(string Email)
        ////{
        ////    AppUser checkemail = await usermanger.FindByEmailAsync(Email);
        ////    if (checkemail != null)
        ////    {
        ////        return true;
        ////    }
        ////    else
        ////    {
        ////        return false;
        ////    }
        ////}

        //public async Task<IList<string>> GetUserRoles(AppUser user)
        //{
        //    var role = await _usermanger.GetRolesAsync(user);

        //    return role;
        //}
        //public async Task<AppUser> GetUserByEmail(string email)
        //{
        //    AppUser user = await _usermanger.FindByEmailAsync(email);
        //    return user;
        //}
        //public async Task<string> JWT()
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gh_ah_na_zi_he_0123456789"));

        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //    expires: DateTime.Now.AddMonths(3),
        //    signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}
    }
}
