using AIMGSM.ViewModels;
using AIMGSM.Models;

namespace AIMGSM.Interfaces
{
    public interface IServiceService
    {
        public void AddService(ServiceVM serviceVM);
        public List<ServiceVM> GetAllServices();
        public ServiceVM GetServiceById(int id);
        public void RemoveService(int id);
        public void EditService(int id);
    }
}
