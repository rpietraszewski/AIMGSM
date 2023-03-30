using AIMGSM.Models;
using AIMGSM.ViewModels;

namespace AIMGSM.Interfaces
{
    public interface IServiceRepository
    {
        public List<Service> GetAllServices();
    }
}
