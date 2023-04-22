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
                PriceVM price = new PriceVM();
                ServiceVM serviceVM = new ServiceVM()
                {
                    Model = device.Model,
                    Brand = device.Brand,
                    SecondPrice = price.SecondPrice,
                    PriceOriginal=price.OriginalPrice,
                    Name= element.Name,
                };
                obj.Add(serviceVM);
            });
            return obj;
        }

    }
}
