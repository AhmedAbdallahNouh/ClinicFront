using ClincApi.Models;
using ClincApi.Repositeries;
using ClinicModels.DTOs.ArticleDto;
using ClinicModels.DTOs.DoctorDTO;
using ClinicModels.DTOs.DoctorServiceDTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClincApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepo _doctorServiceRepo;

        public ServiceController(IServiceRepo doctorServiceRepo)
        {
            this._doctorServiceRepo = doctorServiceRepo;
        }
        // GET: api/<DoctorServiceController>
        [HttpGet("/api/getallservicesforonedoctor/{id}")]
        public async Task<IActionResult> GetAllServicesForOneDoctor(string id)
        {
            try
            {
                List<Service> Services = await _doctorServiceRepo.GetAllServicesToOneDoctor(id);
                if (Services == null)
                {
                    return NotFound();
                }
                else
                {
                    List<ServiceDTO> serviceDTOs = new List<ServiceDTO>();
                    foreach (Service service in Services)
                    {
                        ServiceDTO serviceDTO = new ServiceDTO()
                        {
                            Id = service.Id,
                            Title = service.Title,
                            Discription = service.Discription,
                            Image = service.Image,
                            Category_Id = service.Category_Id,
                            Category_Name = service.category.Name,
                        };
                        serviceDTOs.Add(serviceDTO);
                    }
                    return Ok(serviceDTOs);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetServiceById(int serviceid)
        {
            try
            {
                Service service = _doctorServiceRepo.GetServiceByIdWithOutclude(serviceid);
                if (service == null)
                {
                    return NotFound();
                }
                else
                {
                    ServiceDTO serviceDTO = new ServiceDTO()
                    {
                        Id = service.Id,
                        Title = service.Title,
                        Discription = service.Discription,
                        Image = service.Image,
                        Category_Id = service.Category_Id,
                        Category_Name = service.category.Name,
                    };
                    return Ok(serviceDTO);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<DoctorServiceController>/5
        [HttpGet("/api/doctorid/{id:int}")]
        public async Task<IActionResult> GetServiceByIdWithHisDoctors(int id)
        {
            Service service = await _doctorServiceRepo.GetServiceByIdWithInclude(id);
            if (service == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    ServiceDTO serviceDTO = new ServiceDTO()
                    {
                        Id= service.Id,
                        Title = service.Title,
                        Image = service.Image,
                        Discription= service.Discription,
                        Category_Id = service.Category_Id,
                        doctorDTOs = service.doctorService.Select(s => new DoctorDTO { Id = s.AppUser.Id, FirstName = s.AppUser.FirstName, LastName = s.AppUser.LastName, Image = s.AppUser.Image, Discription = s.AppUser.Discription}).ToList()
                    };
                    return Ok(serviceDTO);
                } catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctorService(ServiceDTO serviceDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service service = new Service()
                    {
                        Title = serviceDTO.Title,
                        Discription = serviceDTO.Discription,
                        Image = serviceDTO.Image,
                        Category_Id = serviceDTO.Category_Id,
                    };
                    Service response = await _doctorServiceRepo.AddService(service);
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

        [HttpPut]
        public IActionResult UpdateService(ServiceDTO serviceDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service service = new Service()
                    {
                        Id = serviceDTO.Id,
                        Title = serviceDTO.Title,
                        Discription = serviceDTO.Discription,
                        Image = serviceDTO.Image,
                        Category_Id = serviceDTO.Category_Id
                    };
                    bool response = _doctorServiceRepo.UpdateService(service);
                    if (response == true) return Ok(response);
                    return BadRequest("there is error In server");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(ModelState.Values.ToString());
        }


    [HttpDelete]
    public IActionResult DeleteService(int id)
        {
            Service Service = _doctorServiceRepo.GetServiceByIdWithOutclude(id);
            if (Service == null)
            {
                return NotFound();
            }
            else
            {
                var response = _doctorServiceRepo.DeleteService(Service);
                if (response == true)
                {
                    return NoContent();
                }
                return BadRequest("There Is Error In Server");
            }
        }     
    }
}
