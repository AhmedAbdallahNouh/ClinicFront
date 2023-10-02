using ClincApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ClincApi.Repositeries
{
    public class AppUserRepo
    {
        ClinicDBContext Db;
        private readonly UserManager<AppUser> usermanger;
        private readonly SignInManager<AppUser> signmanger;

        public AppUserRepo(ClinicDBContext db, UserManager<AppUser> usermanger, SignInManager<AppUser> signInManager)
        {
            Db = db;
            this.usermanger = usermanger;
            this.signmanger = signInManager;
        }
        public List<AppUser> Getallusers()
        {
            //return usermanger.Users.ToList();
            return Db.Users.ToList();
        }
        public async Task<IList<AppUser>> Getalladmin()
        {
            return await usermanger.GetUsersInRoleAsync("admin");
        }
        public AppUser GetuserbyId(string id)
        {
            //return await usermanger.FindByIdAsync(id);
            var user = Db.Users.SingleOrDefault(u => u.Id == id);
            return user;
        }

        public async Task<IdentityResult> AddUser(AppUser user, string password)
        {
            return await usermanger.CreateAsync(user, password);
        }

        public async Task<IdentityResult> Addadmin(AppUser user, string password, string rolename)
        {
            IdentityResult Add_user_to_role = await usermanger.AddToRoleAsync(user, rolename);
            return Add_user_to_role;
        }

        public async Task<IdentityResult> DeleteUser(AppUser user)
        {
            return await usermanger.DeleteAsync(user);
        }

        public async void Update(AppUser user)
        {
            AppUser user1 = Db.Users.FirstOrDefault(u => u.Id == user.Id);

            user1.firstName = user.firstName;
            user1.LastName = user.LastName;
            user1.UserName = $"{user.firstName}{user.LastName}";
            user1.Age = user.Age;
            user1.Address = user.Address;
            user1.FaceBook = user.FaceBook;
            user1.WhatsUpNumber = user.WhatsUpNumber;
            user1.Instgram = user.Instgram;
            user1.LocationLat = user.LocationLat;
            user1.LocationLong = user.LocationLong;
            user1.Age = user.Age;
            user1.Email = user.Email;
            user1.PhoneNumber = user.PhoneNumber;
            Db.SaveChanges();
        }

        public async Task<bool> Logincheck(string password, string Email)
        {
            AppUser checkemail = await usermanger.FindByEmailAsync(Email);
            if (checkemail != null)
            {
                SignInResult result = await signmanger.PasswordSignInAsync(checkemail, password, true, false);
                if (result.Succeeded == true)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public async Task<bool> checkEmails(string Email)
        {
            AppUser checkemail = await usermanger.FindByEmailAsync(Email);
            if (checkemail != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<IList<string>> user_role(AppUser user)
        {
            var role = await usermanger.GetRolesAsync(user);

            return role;
        }
        public async Task<AppUser> getuser_byEmail(string email)
        {
            AppUser user = await usermanger.FindByEmailAsync(email);

            return user;
        }
        public async Task<string> JWT()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gh_ah_na_zi_he_0123456789"));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            expires: DateTime.Now.AddMonths(3),
            signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
