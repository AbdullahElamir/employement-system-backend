namespace WebServerAPI.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebServerAPI.Modules;

    public interface IExperienceReqRepository
    {
        Task<IEnumerable<ExperinceRequirment>> GetAllAsync();
        Task<ExperinceRequirment?> GetByIdAsync(int id);
        Task<ExperinceRequirment?> AddAsync(ExperinceRequirment experienceReq);
        Task<ExperinceRequirment?> UpdateAsync(ExperinceRequirment experienceReq);
        Task<bool> DeleteAsync(int id);
    }
}
