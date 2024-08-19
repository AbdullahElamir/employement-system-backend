using System.Collections.Generic;
using System.Threading.Tasks;
using WebServerAPI.Modules;
using WebServerAPI.Repository;

public class ExperienceReqService : IExperienceReqService
{
    private readonly WebServerAPI.Repository.IExperienceReqRepository _repository;

    public ExperienceReqService(WebServerAPI.Repository.IExperienceReqRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<ExperinceRequirment>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }

    public Task<ExperinceRequirment?> GetByIdAsync(int id)
    {
        return _repository.GetByIdAsync(id);
    }

    public Task<ExperinceRequirment?> AddAsync(ExperinceRequirment experienceReq)
    {
        return _repository.AddAsync(experienceReq);
    }

    public Task<ExperinceRequirment?> UpdateAsync(int id, ExperinceRequirment experienceReq)
    {
        experienceReq.ExperienceRequirementId = id; // Ensure the ID is set
        return _repository.UpdateAsync(experienceReq);
    }

    public Task<bool> DeleteAsync(int id)
    {
        return _repository.DeleteAsync(id);
    }
}
