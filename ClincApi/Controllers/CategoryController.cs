using ClincApi.Models;
using ClincApi.Repositeries;
using ClinicModels;
using ClinicModels.DTOs.DoctorServiceDTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClincApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepo _categoryRepo;
        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }


        [HttpGet]
        public ActionResult GetAllCategories()
        {
            List<Category> categories = _categoryRepo.GetAllCategories();
            if (categories == null)
            {
                return NotFound();
            }
            else
            {
                List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();
                foreach (Category category in categories)
                {
                    CategoryDTO categoryDTO = new CategoryDTO()
                    {
                        Id = category.Id,
                        Name = category.Name
                    };
                    categoryDTOs.Add(categoryDTO);
                }
                return Ok(categoryDTOs);
            }
        }
        
        [HttpGet("/api/GetCategoriespagination")]
        public ActionResult GetCategoriespagination()
        {
            try{
                List<Category> categories = _categoryRepo.GetCategoriespagination();
                if (categories == null)
                {
                    return NotFound();
                }
                else
                {
                    List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();
                    foreach (Category category in categories)
                    {
                        CategoryDTO categoryDTO = new CategoryDTO()
                        {
                            Id = category.Id,
                            Name = category.Name
                        };
                        categoryDTOs.Add(categoryDTO);
                    }
                    return Ok(categoryDTOs);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        
        [HttpGet("/api/getcategorieswithhisservice")]
        public ActionResult GetAllCategoriesWithHisservice()
        {
            List<Category> categories = _categoryRepo.GetAllCategoriesWithHisServices();
            if (categories == null)
            {
                return NotFound();
            }
            else
            {
                List<CategoryDTO> categoryDTOs = new List<CategoryDTO>();
                foreach (Category category in categories)
                {
                    CategoryDTO categoryDTO = new CategoryDTO()
                    {
                        Id = category.Id,
                        Name = category.Name,
                        serviceDTOs = category.doctorServices.Select(s => new ServiceDTO() { Id = s.Id, Category_Id = s.Category_Id, Title = s.Title, Discription = s.Discription, Image = s.Image }).ToList()
                    };
                    categoryDTOs.Add(categoryDTO);
                }
                return Ok(categoryDTOs);
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult GetCategoryById(int id)
        {
            Category category = _categoryRepo.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            CategoryDTO categoryDTO = new CategoryDTO()
            {
                Id = category.Id,
                Name = category.Name
            };
            return Ok(categoryDTO);
        }

        [HttpPut]
        public ActionResult UpdateCategory(CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    Category category = new Category()
                    {
                        Id = categoryDTO.Id,
                        Name = categoryDTO.Name
                    };
                    _categoryRepo.UpdateCategory(category);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

        }
        [HttpPost]
        public ActionResult AddCategory(CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                try
                {
                    Category category = new Category()
                    {
                        Id = categoryDTO.Id,
                        Name = categoryDTO.Name
                    };
                    _categoryRepo.addCategory(category);
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
          
        }

        [HttpDelete]
        public ActionResult DeleteCategory(int id)
        {
            if (_categoryRepo.GetCategoryById(id) == null)
            {
                return NotFound();
            }
            else
            {
                _categoryRepo.deleteCategory(id);
                return NoContent();
            }
        }
    }
}
