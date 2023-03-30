using AIMGSM.Models;
using AIMGSM.Contexts;

namespace AIMGSM.Repositories
{
    public class ServiceRepository
    {
        private readonly ServiceContext _context;
        public ServiceRepository(ServiceContext context)
        {
            _context = context;
        }
        public IQueryable<Service> GetAllServices()
        {
            return _context.Service.OrderBy(s => s.Id);
        }
    }
}
