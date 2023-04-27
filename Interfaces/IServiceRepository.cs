using AIMGSM.Models;
using AIMGSM.ViewModels;

namespace AIMGSM.Interfaces
{
    public interface IServiceRepository
    {
        public void AddService(Service service);
        public List<Service> GetAllServices();
    }
}
