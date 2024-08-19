using System.Linq;
using System.Linq.Expressions;
using WebServerAPI.DTOs;
using WebServerAPI.Modules;

namespace WebServerAPI.Services
{
    public class CareerServices : ICareerServices
    {
        private readonly EmploymentSystemContext _context;

        public CareerServices(EmploymentSystemContext context)
        {
            _context = context;
        }

        public List<Career> GetAllCareers(int pageNumber, int pageSize)
        {
            return _context.Careers
                           .Skip((pageNumber - 1) * pageSize)
                           .Take(pageSize)
                           .ToList();
        }

        public Career GetCareerById(long careerId)
        {
            return _context.Careers.Find(careerId);
        }

        public Career AddCareer(Career career)
        {
            _context.Careers.Add(career);
            _context.SaveChanges();
            return career;
        }

        public void UpdateCareer(Career career)
        {
            _context.Careers.Update(career);
            _context.SaveChanges();
        }

        public void DeleteCareer(long careerId)
        {
            var career = _context.Careers.FirstOrDefault(c => c.CareerId == careerId);
            if (career != null)
            {
                _context.Careers.Remove(career);
                _context.SaveChanges();
            }
        }

        public List<Career> SearchCareers(string searchTerm, int pageNumber, int pageSize)
        {
            searchTerm = searchTerm.ToLower();

            return _context.Careers
                           .Where(c =>
                               (c.Title != null && c.Title.ToLower().Contains(searchTerm)) ||
                               (c.Descriptions != null && c.Descriptions.ToLower().Contains(searchTerm)) ||
                               (c.Requirements != null && c.Requirements.ToLower().Contains(searchTerm))
                           )
                           .Skip((pageNumber - 1) * pageSize)
                           .Take(pageSize)
                           .ToList();
        }
    }
}
