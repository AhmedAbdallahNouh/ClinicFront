using ClincApi.Models;
using ClincApi.Repositeries;
using ClinicModels.DTOs.DoctorServiceDTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClincApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorServiceController : ControllerBase
    {
        private readonly IDoctorServiceRepo _doctorServiceRepo;

        public DoctorServiceController(IDoctorServiceRepo doctorServiceRepo)
        {
            this._doctorServiceRepo = doctorServiceRepo;
        }
        // GET: api/<DoctorServiceController>
        [HttpGet]
        public async Task<IActionResult> GetAllDoctorServices(string doctorId)
        {
            try
            {
              List<DoctorService> doctorServices =  await _doctorServiceRepo.GetAllDoctorServices(doctorId);
              if(doctorServices.Count == 0) return NotFound();
              return Ok(doctorServices);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<DoctorServiceController>/5
        [HttpGet("/api/getdoctorservice")]
        public async Task<IActionResult> GetDoctorServiceById(string doctorId, int serviceId)
        {
            if (!string.IsNullOrWhiteSpace(doctorId) && serviceId != 0)
            {
                try
                {
                    DoctorService doctorService = await _doctorServiceRepo.GetDoctorServiceById(doctorId, serviceId);
                    return Ok(doctorService);

                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                    
                }
            }

            return BadRequest("Null DoctorId Or serviceId ");
           
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctorService(DoctorServiceDTO doctorServiceDTO)
        {
            if(ModelState.IsValid)
            {
                try
                {
                  DoctorServiceDTO doctorServiceToAddDTO = await _doctorServiceRepo.AddDoctorService(doctorServiceDTO);
                  return Ok(doctorServiceToAddDTO);
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

        // POST api/<DoctorServiceController>


        [HttpPut]
        public async Task<IActionResult> UpdateService(DoctorServiceDTO doctorServiceDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DoctorServiceDTO doctorServiceToUpdateDTO = await _doctorServiceRepo.UpdateService(doctorServiceDTO);
                    return Ok(doctorServiceToUpdateDTO);
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState.Values.ToString());
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteService(string doctorId, int serviceId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    DoctorServiceDTO doctorServiceToDeleteDTO = await _doctorServiceRepo.DeleteService(doctorId, serviceId);
                    return Ok(doctorServiceToDeleteDTO);
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState.Values.ToString());
        }     
    }
}
