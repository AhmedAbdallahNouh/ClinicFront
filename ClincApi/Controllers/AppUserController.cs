using ClincApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicModels;
using Microsoft.AspNetCore.Authorization;
using ClinicModels.DTOs.MainDTO;
using ClinicModels.DTOs.DoctorDTO;
using ClinicModels.DTOs.DoctorServiceDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClincApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signmanger;
        public AppUserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this._userManager = userManager;
            this._signmanger = signInManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            List<AppUser> users = await _userManager.Users.ToListAsync();
            if (users.Count != 0) return Ok(users);
            else return NotFound();
        }
        [HttpGet("/api/getalldoctors")]
        public async Task<ActionResult> GetAllDoctors()
        {
            List<AppUser> users = (List<AppUser>) await _userManager.GetUsersInRoleAsync("Doctor");
            if (users.Count != 0) return Ok(users);
            else return NotFound();
        }
        [HttpGet("/api/getalladmins")]
        public async Task<ActionResult> GetAllAdmins()
        {
            List<AppUser> users = (List<AppUser>)await _userManager.GetUsersInRoleAsync("Admin");
            if (users.Count != 0) return Ok(users);
            else return NotFound();
        }

        [HttpGet("/api/getuserbyid")]    
        public async Task<AppUser> GetUserbyIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return user;

            //var user = this._clinicDBContext.Users.SingleOrDefault(u => u.Id == id);
        }
        [HttpGet("/api/getdoctorbyid")]
        public async Task<IActionResult> GetDoctorbyIdAsync(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                  var doctor = await _userManager.Users
                 .Include(d => d.Services)
                 .Include(d => d.Category)
                 .SingleOrDefaultAsync(u => u.Id == id);
                     
               if (doctor != null)
               {
                     DoctorDTO doctorDTO = new DoctorDTO(id , doctor.FirstName, doctor.LastName,doctor.Age,doctor.PhoneNumber,doctor.Address
                       ,doctor.LocationLat,doctor.LocationLong,doctor.FaceBook,doctor.Instgram,doctor.WhatsUpNumber);
               
                     CategoryDTO categoryDTO = new CategoryDTO()
                     {
                         Id = (int)doctor.CategoryId,
                         Name = doctor.Category.Name,
               
                     };
                   doctorDTO.categoryDTO = categoryDTO;
               
                   foreach(var doctorService in doctor.Services)
                   {
                         DoctorServiceDTO doctorServiceDTO = new DoctorServiceDTO()
                         {
                             Id = doctorService.Id,
                             Title = doctorService.Title,
                             Discription = doctorService.Discription,
                             Image = doctorService.Image,
                         };
                         doctorDTO.doctorServiceDTOs.Add(doctorServiceDTO);
               
                   }
                     return Ok(doctorDTO);
               }
               return NotFound("not found");
            }                    
            return BadRequest("id is null or empty");
        }

        [HttpPost]
        public async Task<ActionResult> AdminRegistration(AdminRegiterationDTO adminRegiterationDTO)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    FirstName = adminRegiterationDTO.FirstName,
                    LastName = adminRegiterationDTO.LastName,
                    UserName = adminRegiterationDTO.UserName,
                    Email = adminRegiterationDTO.Email,
                    PhoneNumber = adminRegiterationDTO.PhoneNumber,
                    Address = adminRegiterationDTO.Address,
                    Age = adminRegiterationDTO.Age,
                };
                IdentityResult addUserResult = await _userManager.CreateAsync(user, adminRegiterationDTO.Password);


                adminRegiterationDTO.Id = user.Id;
                if (addUserResult.Succeeded)
                {
                    try
                    {
                        IdentityResult addRoleToUserResult = await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    catch { }
                    return Ok(adminRegiterationDTO);
                }
                else return BadRequest();
            }
            return BadRequest("model state invalid");
        }

        [HttpPost("/api/doctorregister")]
        public async Task<ActionResult> DoctorRegisterationByAmdin(DoctorRegisterationByAmdinDTO doctorRegisterationByAmdinDTO)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {   StartSubscriptionDate = doctorRegisterationByAmdinDTO.StartSubscriptionDate,
                    EndSubscriptionDate = doctorRegisterationByAmdinDTO.EndSubscriptionDate,
                    UserName = doctorRegisterationByAmdinDTO.UserName,                                 
                };
                IdentityResult addUserResult = await _userManager.CreateAsync(user, doctorRegisterationByAmdinDTO.Password);
                doctorRegisterationByAmdinDTO.Id = user.Id;
                if (addUserResult.Succeeded )
                {
                    try
                    {
                        IdentityResult addRoleToUserResult = await _userManager.AddToRoleAsync(user, "Doctor");
                    }
                    catch { }
                    return Ok(doctorRegisterationByAmdinDTO);
                }
                else return BadRequest();
            }
            return BadRequest("model state invalid");
        }
        [HttpPut("/api/editdoctorprofile")]
        public async Task<ActionResult> EditDoctorProflie(DoctorUpdatingProfileDTO doctorUpdatingProfileDTO)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    AppUser? doctorToUpdateProfile = await GetUserbyIdAsync(doctorUpdatingProfileDTO.Id);
                    if (doctorToUpdateProfile != null)
                    {

                        doctorToUpdateProfile.FirstName = doctorUpdatingProfileDTO.FirstName;
                        doctorToUpdateProfile.LastName = doctorUpdatingProfileDTO.LastName;
                        doctorToUpdateProfile.Email = doctorUpdatingProfileDTO.Email;
                        doctorToUpdateProfile.PhoneNumber = doctorUpdatingProfileDTO.PhoneNumber;
                        doctorToUpdateProfile.Address = doctorUpdatingProfileDTO.Address;
                        doctorToUpdateProfile.Age = doctorUpdatingProfileDTO.Age;
                        doctorToUpdateProfile.LocationLat = doctorUpdatingProfileDTO.LocationLat;
                        doctorToUpdateProfile.LocationLong = doctorUpdatingProfileDTO.LocationLong;
                        doctorToUpdateProfile.WhatsUpNumber = doctorUpdatingProfileDTO.WhatsUpNumber;

                        IdentityResult updateDoctorProfileResult = await _userManager.UpdateAsync(doctorToUpdateProfile);
                        return updateDoctorProfileResult.Succeeded ? Ok(doctorToUpdateProfile) : BadRequest("faild to save changes");

                    }
                    else return NotFound("user is null");

                }
                return BadRequest("model state invalid");

            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }
           
           
        }
        [HttpPut("/api/editadminprofile")]
        public async Task<ActionResult> EditAdminProfile(AdminRegiterationDTO adminRegiterationDTO)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    AppUser? adminToUpdateProfile = await GetUserbyIdAsync(adminRegiterationDTO.Id);
                    if (adminToUpdateProfile != null)
                    {

                        adminToUpdateProfile.FirstName = adminToUpdateProfile.FirstName;
                        adminToUpdateProfile.LastName = adminToUpdateProfile.LastName;
                        adminToUpdateProfile.Email = adminToUpdateProfile.Email;
                        adminToUpdateProfile.PhoneNumber = adminToUpdateProfile.PhoneNumber;
                        adminToUpdateProfile.Address = adminToUpdateProfile.Address;
                        adminToUpdateProfile.Age = adminToUpdateProfile.Age;
                        adminToUpdateProfile.UserName = adminToUpdateProfile.UserName;

                        IdentityResult updateAdminProfileResult = await _userManager.UpdateAsync(adminToUpdateProfile);
                        return updateAdminProfileResult.Succeeded ? Ok(adminToUpdateProfile) : BadRequest("faild to save changes");

                    }
                    else return NotFound("user is null");

                }
                return BadRequest("model state invalid");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        //[HttpPost("/api/login")]
        //public async Task<IActionResult> Login(LoginDTO loginDTO)
        //{
        //    //var ReturnUrl = Url.Content("True");
        //    if (ModelState.IsValid)
        //    {
        //        var result = await _signmanger.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, false, lockoutOnFailure: false);
        //        if (result.Succeeded)
        //        {
        //            return Ok(true);
        //        }
        //        return NotFound(false);
        //    }
        //    return BadRequest(false);
        //}


    }
}
