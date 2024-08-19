using System.Linq;
using WebServerAPI.Modules;

namespace WebServerAPI.Services
{
    public interface ICareerServices
    {
        Career AddCareer(Career career);

        void UpdateCareer(Career career);

        void DeleteCareer(long careerId);

        List<Career> GetAllCareers(int pageNumber = 1, int pageSize = 10);

        Career GetCareerById(long careerId);

        public List<Career> SearchCareers(string searchTerm, int pageNumber = 1, int pageSize = 10);
    }
}
