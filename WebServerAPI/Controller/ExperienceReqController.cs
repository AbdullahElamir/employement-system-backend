using Microsoft.AspNetCore.Mvc;
using WebServerAPI.Modules;
using WebServerAPI.Repository;



[ApiController]
[Route("api/[controller]")]
public class ExperienceReqController : ControllerBase
{
    private readonly IExperienceReqService _service;

    public ExperienceReqController(IExperienceReqService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExperinceRequirment>>> GetAll()
    {
        var experienceReqs = await _service.GetAllAsync();
        return Ok(experienceReqs);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExperinceRequirment>> GetById(int id)
    {
        var experienceReq = await _service.GetByIdAsync(id);
        if (experienceReq == null)
        {
            return NotFound(); // Return 404 if not found
        }
        return Ok(experienceReq); // Return 200 OK with the result
    }

    [HttpPost]
    public async Task<ActionResult<ExperinceRequirment>> Create(ExperinceRequirment experienceReq)
    {
        if (experienceReq == null)
        {
            return BadRequest("Experience requirement cannot be null.");
        }

        var createdExperienceReq = await _service.AddAsync(experienceReq);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        return CreatedAtAction(nameof(GetById), new { id = createdExperienceReq.ExperienceRequirementId }, createdExperienceReq);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ExperinceRequirment experienceReq)
    {
        if (experienceReq == null || id != experienceReq.ExperienceRequirementId)
        {
            return BadRequest("Invalid data.");
        }

        var updatedExperienceReq = await _service.UpdateAsync(id, experienceReq);
        if (updatedExperienceReq == null)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.DeleteAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
