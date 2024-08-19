using System.Linq;
using System.Linq.Expressions;
using WebServerAPI.DTOs;
using WebServerAPI.Modules;

namespace WebServerAPI.Services
{
    public class ApplicantServices : IApplicantServices
    {
        private readonly EmploymentSystemContext _context;

        public ApplicantServices(EmploymentSystemContext context)
        {
            _context = context;
        }

        public List<Applicant> GetAllApplicants(int pageNumber, int pageSize)
        {
            return _context.Applicants
                           .Skip((pageNumber - 1) * pageSize)
                           .Take(pageSize)
                           .ToList();
        }

        public Applicant GetApplicantById(long applicantId)
        {
            return _context.Applicants.Find(applicantId);
        }

        public Applicant AddApplicant(Applicant applicant)
        {
            _context.Applicants.Add(applicant);
            _context.SaveChanges();
            return applicant;
        }

        public void UpdateApplicant(Applicant applicant)
        {
            _context.Applicants.Update(applicant);
            _context.SaveChanges();
        }

        public void DeleteApplicant(long applicantId)
        {
            var applicant = _context.Applicants.FirstOrDefault(a => a.ApplicantId == applicantId);
            if (applicant != null)
            {
                _context.Applicants.Remove(applicant);
                _context.SaveChanges();
            }
        }

        public List<Applicant> SearchApplicants(string searchTerm, int pageNumber, int pageSize)
        {
            searchTerm = searchTerm.ToLower();

            return _context.Applicants
                           .Where(a =>
                               (a.Nid != null && a.Nid.ToLower().Contains(searchTerm)) ||
                               (a.FirstName != null && a.FirstName.ToLower().Contains(searchTerm)) ||
                               (a.FatherName != null && a.FatherName.ToLower().Contains(searchTerm)) ||
                               (a.GrandFatherName != null && a.GrandFatherName.ToLower().Contains(searchTerm)) ||
                               (a.SurName != null && a.SurName.ToLower().Contains(searchTerm)) ||
                               (a.Email != null && a.Email.ToLower().Contains(searchTerm)) ||
                               (a.PhoneNumber1 != null && a.PhoneNumber1.ToLower().Contains(searchTerm)) ||
                               (a.PhoneNumber2 != null && a.PhoneNumber2.ToLower().Contains(searchTerm))
                           )
                           .Skip((pageNumber - 1) * pageSize)
                           .Take(pageSize)
                           .ToList();
        }

    }
}
