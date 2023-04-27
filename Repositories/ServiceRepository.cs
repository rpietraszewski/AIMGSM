using AIMGSM.Models;
using AIMGSM.Contexts;

namespace AIMGSM.Repositories
{
    public class ServiceRepository
    {
        private readonly GlobalContext _context;
        public ServiceRepository(GlobalContext context)
        {
            _context = context;
        }
        public void AddService(Service service)
        {
            _context.Service.Add(service);
            _context.SaveChanges();
        }
        public IQueryable<Service> GetAllServices()
        {
            return _context.Service.OrderBy(s => s.Id);
        }
    }
}
