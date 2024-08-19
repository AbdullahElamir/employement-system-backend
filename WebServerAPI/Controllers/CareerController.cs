using Microsoft.AspNetCore.Mvc;
using WebServerAPI.Modules;
using WebServerAPI.Services;
using WebServerAPI.DTOs;

namespace WebServerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CareerController : Controller
    {
        private readonly ICareerServices _careerService;

        public CareerController(ICareerServices careerService)
        {
            _careerService = careerService;
        }

        [HttpGet]
        public IActionResult GetAllCareers(int pageNumber = 1, int pageSize = 10)
        {
            var careers = _careerService.GetAllCareers(pageNumber, pageSize);
            return Ok(careers);
        }

        [HttpGet("{id}")]
        public IActionResult GetCareerById(long id)
        {
            var career = _careerService.GetCareerById(id);
            if (career == null)
            {
                return NotFound();
            }
            return Ok(career);
        }

        [HttpPost]
        public IActionResult AddCareer([FromBody] CareerDTO careerDto)
        {
            var career = new Career
            {
                Title = careerDto.Title,
                Descriptions = careerDto.Descriptions,
                Requirements = careerDto.Requirements,
                ExperienceRequirementId = careerDto.ExperienceRequirementId,
                EducationId = careerDto.EducationId,
                PostionType = careerDto.PostionType,
                LocationId = careerDto.LocationId,
                Salary = careerDto.Salary,
                IsPublished = careerDto.IsPublished,
                ApplicationExpirationDate = careerDto.ApplicationExpirationDate,
                CreatedOn = careerDto.CreatedOn,
                CreatedBy = careerDto.CreatedBy,
                Status = careerDto.Status,
                RefrenceCode = careerDto.RefrenceCode
            };

            _careerService.AddCareer(career);

            return Ok(careerDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCareer(long id, CareerDTO careerDto)
        {
            if (id != careerDto.CareerId)
            {
                return BadRequest();
            }

            var career = new Career
            {
                CareerId = id,
                Title = careerDto.Title,
                Descriptions = careerDto.Descriptions,
                Requirements = careerDto.Requirements,
                ExperienceRequirementId = careerDto.ExperienceRequirementId,
                EducationId = careerDto.EducationId,
                PostionType = careerDto.PostionType,
                LocationId = careerDto.LocationId,
                Salary = careerDto.Salary,
                IsPublished = careerDto.IsPublished,
                ApplicationExpirationDate = careerDto.ApplicationExpirationDate,
                CreatedOn = careerDto.CreatedOn,
                CreatedBy = careerDto.CreatedBy,
                Status = careerDto.Status,
                RefrenceCode = careerDto.RefrenceCode
            };

            _careerService.UpdateCareer(career);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCareer(long id)
        {
            _careerService.DeleteCareer(id);
            return NoContent();
        }

        [HttpGet("search")]
        public ActionResult<List<CareerDTO>> SearchCareers(string searchTerm, int pageNumber = 1, int pageSize = 10)
        {
            
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                var allCareers = _careerService.GetAllCareers(pageNumber, pageSize);

                var careerDtos = allCareers.Select(c => new CareerDTO
                {
                    CareerId = c.CareerId,
                    Title = c.Title,
                    Descriptions = c.Descriptions,
                    Requirements = c.Requirements,
                    ExperienceRequirementId = c.ExperienceRequirementId,
                    EducationId = c.EducationId,
                    PostionType = c.PostionType,
                    LocationId = c.LocationId,
                    Salary = c.Salary,
                    IsPublished = c.IsPublished,
                    ApplicationExpirationDate = c.ApplicationExpirationDate,
                    CreatedOn = c.CreatedOn,
                    CreatedBy = c.CreatedBy,
                    Status = c.Status,
                    RefrenceCode = c.RefrenceCode
                }).ToList();

                return Ok(careerDtos);
            }
            else
            {
                var careers = _careerService.SearchCareers(searchTerm, pageNumber, pageSize);

                var careerDtos = careers.Select(c => new CareerDTO
                {
                    CareerId = c.CareerId,
                    Title = c.Title,
                    Descriptions = c.Descriptions,
                    Requirements = c.Requirements,
                    ExperienceRequirementId = c.ExperienceRequirementId,
                    EducationId = c.EducationId,
                    PostionType = c.PostionType,
                    LocationId = c.LocationId,
                    Salary = c.Salary,
                    IsPublished = c.IsPublished,
                    ApplicationExpirationDate = c.ApplicationExpirationDate,
                    CreatedOn = c.CreatedOn,
                    CreatedBy = c.CreatedBy,
                    Status = c.Status,
                    RefrenceCode = c.RefrenceCode
                }).ToList();

                return Ok(careerDtos);
            }
        }
    }
}
