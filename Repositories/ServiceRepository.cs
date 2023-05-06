using AIMGSM.Models;
using AIMGSM.Contexts;
using AIMGSM.Interfaces;

namespace AIMGSM.Repositories
{
    public class ServiceRepository : IServiceRepository
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

        public void EditService(int id)
        {
            Service service = _context.Service.FirstOrDefault(y => y.Id == id);
            if (service == null)
            {
                return;
            }
            _context.Service.Update(service);
            _context.SaveChanges();
        }

        public List<Service> GetAllServices()
        {
            return _context.Service.OrderBy(s => s.Id).ToList();

        }

        public Service GetServiceById(int id)
        {
            return _context.Service.FirstOrDefault(y => y.Id == id);
        }

        public void RemoveService(int id)
        {
            Service service = _context.Service.FirstOrDefault(y => y.Id == id);
            if (service == null)
            {
                return;
            }
            _context.Service.Remove(service);
            _context.SaveChanges();
        }
    }
}
