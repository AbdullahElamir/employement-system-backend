using System.Linq;
using WebServerAPI.Modules;

namespace WebServerAPI.Services
{
    public interface IApplicantServices
    {
        Applicant AddApplicant(Applicant applicant);

        void UpdateApplicant(Applicant applicant);

        void DeleteApplicant(long applicantId);

        List<Applicant> GetAllApplicants(int pageNumber = 1, int pageSize = 10);

        Applicant GetApplicantById(long applicantId);

        List<Applicant> SearchApplicants(string searchTerm, int pageNumber = 1, int pageSize = 10);
    }
}
