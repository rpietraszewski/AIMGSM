using AIMGSM.Interfaces;
using AIMGSM.ViewModels;
using Microsoft.Extensions.Logging;
using AIMGSM.Models;

namespace AIMGSM.Services
{
    public class ServiceService : IServiceService
    {
        public readonly IServiceRepository _serviceRespository;
        public ServiceService(IServiceRepository serviceRespository)
        {
            _serviceRespository= serviceRespository;
        }

        public List<ServiceVM> GetAllServices()
        {
            List<Service> list = _serviceRespository.GetAllServices();
            List<ServiceVM> obj = new List<ServiceVM>();
            list.ForEach(element =>
            {
                DeviceVM device = new DeviceVM();
                ServiceVM serviceVM = new ServiceVM()
                {
                    Description= element.Description,
                    Model = device.Model,
                    Brand = device.Brand,
                    PriceFake=element.PriceFake,
                    PriceOriginal=element.PriceOriginal,
                    Name= element.Name,
                };
                obj.Add(serviceVM);
            });
            return obj;
        }

    }
}
