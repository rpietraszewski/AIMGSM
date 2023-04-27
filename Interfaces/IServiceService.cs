using AIMGSM.ViewModels;
using AIMGSM.Models;

namespace AIMGSM.Interfaces
{
    public interface IServiceService
    {
        public void AddService(Service service);
        public List<ServiceVM> GetAllServices();
    }
}
