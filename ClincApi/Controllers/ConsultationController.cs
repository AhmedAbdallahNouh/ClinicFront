using ClincApi.Models;
using ClinicModels.DTOs.ConsultationDTO;
using ClinicModels;
using ClinicModels.DTOs.ConsultationImageDTO;
using ClincApi.Repositeries;
using Microsoft.AspNetCore.Mvc;

namespace ClincApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationRepo _consultationRepo;
        private readonly IConsultationImageRepo _consultationImageRepo;

        public ConsultationController(IConsultationRepo consultationRepo , IConsultationImageRepo consultationImageRepo)
        {
            this._consultationRepo = consultationRepo;
            this._consultationImageRepo = consultationImageRepo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

           List<Consultation> consultations = await _consultationRepo.GetAll();
           if(consultations.Count != 0)
           {
               List<CnosultationDTO> cnosultationDTOs = new List<CnosultationDTO>();
               foreach (var consultation in consultations)
               {
                   CnosultationDTO cnosultationDTO = new CnosultationDTO()
                   {
                       Id = consultation.Id,
                       Question = consultation.Question,
                       Description = consultation.Description,
                       Answer = consultation.Answer,
                       CategoryId = consultation.CategoryId,
                       categoryDTO = new CategoryDTO() { Id = consultation.CategoryId, Name = consultation.Category.Name },
                       consultationImageDTOs = consultation.ConsultationImages.Select(c => new ConsulationImageDTO() { Id = c.Id, Image = c.Image, ConsultationId = c.Id }).ToList(),
                   };
                   cnosultationDTOs.Add(cnosultationDTO);
               }
               return Ok(cnosultationDTOs);
            }
            return NotFound();                  
        }
        [HttpGet("/api/getall/{catergoryId}")]
        public async Task<IActionResult> GetAllForDoctorByCategoryId(int catergoryId)
        {

            List<Consultation> consultations = await _consultationRepo.GetAllForDoctorByCategoryId(catergoryId);
            if (consultations.Count != 0)
            {
                List<CnosultationDTO> cnosultationDTOs = new List<CnosultationDTO>();
                foreach (var consultation in consultations)
                {
                    CnosultationDTO cnosultationDTO = new CnosultationDTO()
                    {
                        Id = consultation.Id,
                        Question = consultation.Question,
                        Description = consultation.Description,
                        Answer = consultation.Answer,
                        CategoryId = consultation.CategoryId,
                        categoryDTO = new CategoryDTO() { Id = consultation.CategoryId, Name = consultation.Category.Name },
                        consultationImageDTOs = consultation.ConsultationImages.Select(c => new ConsulationImageDTO() { Id = c.Id, Image = c.Image, ConsultationId = c.Id }).ToList(),
                    };
                    cnosultationDTOs.Add(cnosultationDTO);
                }
                return Ok(cnosultationDTOs);
            }
            return NotFound();
        }
        [HttpGet("/api/getbyid")]
        public async Task<ActionResult?> GetByID(int id)
        {
            if(id != 0)
            {
            
             Consultation consultation =  await _consultationRepo.GetByID(id);
                if(consultation is not null)
                {
                    CnosultationDTO consultationDTO = new CnosultationDTO()
                    {
                        Id = consultation.Id,
                        Question = consultation.Question,
                        Description = consultation.Description,
                        Answer = consultation.Answer,
                        CategoryId = consultation.CategoryId,
                        consultationImageDTOs = consultation.ConsultationImages.Select(c => new ConsulationImageDTO() { Id = c.Id, Image = c.Image, ConsultationId = c.Id }).ToList(),
                        categoryDTO = new CategoryDTO() { Id= consultation.CategoryId, Name = consultation.Category.Name}
                    };
                    return Ok(consultationDTO);
                }
                return NotFound();
            }
            return BadRequest();          
        }

        [HttpPost]
        public async Task<ActionResult?> Add(AddConsultationDTO cnosultationDTO)
        {
            
            if(ModelState.IsValid)
            {
                
                try
                {
                    Consultation consultationToAdd = new Consultation()
                    {
                        Question = cnosultationDTO.Question,
                        Description = cnosultationDTO.Description,
                        CategoryId = cnosultationDTO.CategoryId,
                        ConsultationImages = cnosultationDTO.consultationImageDTOs.Select(c => new ConsultationImage() { Image = c.Image }).ToList(),
                    };
                    int NumberOfRowEffectedForConsultation = await _consultationRepo.Add(consultationToAdd);                 
                    if (NumberOfRowEffectedForConsultation > 0)
                        return Ok(cnosultationDTO);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return BadRequest("Faild To Save Consultation Image");
                }   
            }
            return BadRequest(string.Empty);

        }
        [HttpPut]
        public async Task<ActionResult?> Update(UpdateConsultationdto cnosultationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                Consultation consultation = await _consultationRepo.GetByID(cnosultationDTO.Id);

                if (consultation == null)
                {
                    return NotFound("Post not found");
                }

                // Update the existing post properties
                consultation.Question = cnosultationDTO.Question;
                consultation.Description = cnosultationDTO.Description;
                consultation.Answer = cnosultationDTO.Answer;
                consultation.CategoryId = cnosultationDTO.CategoryId;

                consultation.ConsultationImages.Clear(); // Remove all existing images

                if (cnosultationDTO.consultationImageDTOs != null && cnosultationDTO.consultationImageDTOs.Any())
                {
                    foreach (var imageDTO in cnosultationDTO.consultationImageDTOs)
                    {
                        consultation.ConsultationImages.Add(new ConsultationImage
                        {
                            Image = imageDTO.Image,
                            ConsultationId = consultation.Id
                        });
                    }
                }
                int NumberOfRowEffected = await _consultationRepo.Update(consultation);
                if (NumberOfRowEffected > 0)
                {

                    return Ok(cnosultationDTO);
                }
                return BadRequest("faild to save changes"); return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult?> Delete(int cnosultationId)
        {         
            if (cnosultationId != 0)
            {
                Consultation? consultationToDelete =  _consultationRepo.GetByID(cnosultationId).Result;
                if (consultationToDelete is null)
                    return NotFound();
               int NumberOfRowEffected = await _consultationRepo.Delete(consultationToDelete);
               if (NumberOfRowEffected > 0) 
                  return NoContent();
               return BadRequest("Faild To Delete Consultation");
            }
            return BadRequest(string.Empty);
        }
    }
}
