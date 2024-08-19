namespace WebServerAPI.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using WebServerAPI.Modules;

    public class ExperienceReqRepository : IExperienceReqRepository
    {
        private readonly EmploymentSystemContext _context;

        public ExperienceReqRepository(EmploymentSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExperinceRequirment>> GetAllAsync()
        {
            return await _context.ExperinceRequirments.ToListAsync();
        }

        public async Task<ExperinceRequirment?> GetByIdAsync(int id)
        {
            return await _context.ExperinceRequirments.FindAsync(id);
        }

        public async Task<ExperinceRequirment?> AddAsync(ExperinceRequirment experienceReq)
        {
            if (experienceReq == null)
            {
                throw new ArgumentNullException(nameof(experienceReq));
            }

            _context.ExperinceRequirments.Add(experienceReq);
            await _context.SaveChangesAsync();
            return experienceReq;
        }

        public async Task<ExperinceRequirment?> UpdateAsync(ExperinceRequirment experienceReq)
        {
            if (experienceReq == null)
            {
                throw new ArgumentNullException(nameof(experienceReq));
            }

            _context.ExperinceRequirments.Update(experienceReq);
            await _context.SaveChangesAsync();
            return experienceReq;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var experienceReq = await _context.ExperinceRequirments.FindAsync(id);
            if (experienceReq == null)
            {
                return false;
            }

            _context.ExperinceRequirments.Remove(experienceReq);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
