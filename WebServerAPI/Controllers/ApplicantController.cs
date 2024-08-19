using Microsoft.AspNetCore.Mvc;
using WebServerAPI.Modules;
using WebServerAPI.Services;
using WebServerAPI.DTOs;


namespace WebServerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicantController : Controller
    {
        private readonly IApplicantServices _applicantService;

        public ApplicantController(IApplicantServices applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpGet]
        public IActionResult GetAllApplicants(int pageNumber = 1, int pageSize = 10)
        {
            var applicants = _applicantService.GetAllApplicants(pageNumber, pageSize);
            return Ok(applicants);
        }

        [HttpGet("{id}")]
        public IActionResult GetApplicantById(long id)
        {
            var applicant = _applicantService.GetApplicantById(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return Ok(applicant);
        }

        [HttpPost]
        public IActionResult AddApplicant([FromBody] ApplicantDTO applicantDto)
        {
            var applicant = new Applicant
            {
                Nid = applicantDto.Nid,
                FirstName = applicantDto.FirstName,
                FatherName = applicantDto.FatherName,
                GrandFatherName = applicantDto.GrandFatherName,
                SurName = applicantDto.SurName,
                Email = applicantDto.Email,
                PhoneNumber1 = applicantDto.PhoneNumber1,
                PhoneNumber2 = applicantDto.PhoneNumber2,
                SalaryExpectations = applicantDto.SalaryExpectations,
                Resume = applicantDto.Resume,
                CoverLetter = applicantDto.CoverLetter,
                CreatedOn = applicantDto.CreatedOn,
                Status = applicantDto.Status,
                CareerId = applicantDto.CareerId
            };

            _applicantService.AddApplicant(applicant);

            return Ok(applicantDto);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateApplicant(long id, ApplicantDTO applicantDto)
        {
            if (id != applicantDto.ApplicantId)
            {
                return BadRequest();
            }

            var applicant = new Applicant
            {
                ApplicantId = id,
                Nid = applicantDto.Nid,
                FirstName = applicantDto.FirstName,
                FatherName = applicantDto.FatherName,
                GrandFatherName = applicantDto.GrandFatherName,
                SurName = applicantDto.SurName,
                Email = applicantDto.Email,
                PhoneNumber1 = applicantDto.PhoneNumber1,
                PhoneNumber2 = applicantDto.PhoneNumber2,
                SalaryExpectations = applicantDto.SalaryExpectations,
                Resume = applicantDto.Resume,
                CoverLetter = applicantDto.CoverLetter,
                CreatedOn = applicantDto.CreatedOn,
                Status = applicantDto.Status,
                CareerId = applicantDto.CareerId
            };

            _applicantService.UpdateApplicant(applicant);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteApplicant(long id)
        {
            _applicantService.DeleteApplicant(id);
            return NoContent();
        }

        [HttpGet("search")]
        public ActionResult<List<ApplicantDTO>> SearchApplicants( string searchTerm, int pageNumber = 1, int pageSize = 10)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                var allApplicants = _applicantService.GetAllApplicants(pageNumber, pageSize);

                var applicantDtos = allApplicants.Select(a => new ApplicantDTO
                {
                    ApplicantId = a.ApplicantId,
                    Nid = a.Nid,
                    FirstName = a.FirstName,
                    FatherName = a.FatherName,
                    GrandFatherName = a.GrandFatherName,
                    SurName = a.SurName,
                    Email = a.Email,
                    PhoneNumber1 = a.PhoneNumber1,
                    PhoneNumber2 = a.PhoneNumber2,
                    SalaryExpectations = a.SalaryExpectations,
                    Resume = a.Resume,
                    CoverLetter = a.CoverLetter,
                    CreatedOn = a.CreatedOn,
                    Status = a.Status,
                    CareerId = a.CareerId
                }).ToList();

                return Ok(applicantDtos);
            }
            else
            {
                var applicants = _applicantService.SearchApplicants(searchTerm, pageNumber, pageSize);

                var applicantDtos = applicants.Select(a => new ApplicantDTO
                {
                    ApplicantId = a.ApplicantId,
                    Nid = a.Nid,
                    FirstName = a.FirstName,
                    FatherName = a.FatherName,
                    GrandFatherName = a.GrandFatherName,
                    SurName = a.SurName,
                    Email = a.Email,
                    PhoneNumber1 = a.PhoneNumber1,
                    PhoneNumber2 = a.PhoneNumber2,
                    SalaryExpectations = a.SalaryExpectations,
                    Resume = a.Resume,
                    CoverLetter = a.CoverLetter,
                    CreatedOn = a.CreatedOn,
                    Status = a.Status,
                    CareerId = a.CareerId
                }).ToList();

                return Ok(applicantDtos);
            }
        }
    }
}
