using ClincApi.Models;
using ClincApi.Repositeries;
using ClinicModels.DTOs.DoctorServiceDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClincApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorServiceController : ControllerBase
    {
        private readonly IDoctorServiceRepo _doctorServiceDTORepo;

        public DoctorServiceController(IDoctorServiceRepo doctorServiceRepoDTO)
        {
            this._doctorServiceDTORepo = doctorServiceRepoDTO;
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctorService(DoctorServiceDto doctorServiceDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DoctorService doctorService = new DoctorService()
                    {
                        Doctor_Id = doctorServiceDto.DoctorServiceId,
                        Service_Id = doctorServiceDto.ServiceId,
                    };
                    DoctorService response = await _doctorServiceDTORepo.AddServiceToDoctor(doctorService);
                    if (response != null) return Ok(response);
                    return BadRequest("there is error In server");
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest(ModelState.Values.ToString());

            }
        }

        [HttpDelete]
        public IActionResult DeleteService(string doctorId, int serviceId)
        {
            DoctorService doctorService = _doctorServiceDTORepo.GetDoctorServiceById(doctorId,serviceId);
            if (doctorService == null)
            {
                return NotFound();
            }
            else
            {
                var response = _doctorServiceDTORepo.DeleteServiceFromDoctor(doctorService);
                if (response == true)
                {
                    return NoContent();
                }
                return BadRequest("There Is Error In Server");
            }
        }
    }
}
