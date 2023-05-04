using AIMGSM.Interfaces;
using AIMGSM.Models;
using AIMGSM.Repositories;
using AIMGSM.ViewModels;
using Microsoft.Extensions.Logging;

namespace AIMGSM.Services
{
    public class PriceService : IPriceService
    {
        private readonly IPriceRepository _priceRepository;
        private readonly IDeviceService _deviceService;
        private readonly IServiceService _serviceService;
        public PriceService(IPriceRepository priceRepository, IDeviceService deviceService, IServiceService serviceService)
        {
            _priceRepository = priceRepository;
            _deviceService = deviceService;
            _serviceService = serviceService;
        }
        public void AddPrice(PriceVM priceVM,int deviceId, int serviceId)
        {
            DeviceVM device = _deviceService.GetDeviceById(deviceId);
            ServiceVM service = _serviceService.GetServiceById(serviceId);
            Price obj = new Price()
            {
                Id = priceVM.Id,
                OriginalPrice = priceVM.OriginalPrice,
                SecondPrice = priceVM.SecondPrice,
                DeviceId= device.Id,
                ServiceId= service.Id,
            };
            _priceRepository.AddPrice(obj);
        }

        public List<PriceVM> GetAllPrices()
        {
            List<Price> list = _priceRepository.GetAllPrices();
            if (list.Count == 0)
            {
                return new List<PriceVM>();
            }
            List<PriceVM> result = new List<PriceVM>();
            list.ForEach(element =>
            {
                DeviceVM device = _deviceService.GetDeviceById(element.Id);
                ServiceVM service = _serviceService.GetServiceById(element.Id);
                PriceVM resultVM = new PriceVM()
                {
                    Id = element.Id,
                    OriginalPrice = element.OriginalPrice,
                    SecondPrice = element.SecondPrice,
                    Name = service.Name,
                    Brand = device.Brand,
                    Model = device.Model,
                };
                result.Add(resultVM);
            });
            return result;
        }

        public PriceVM GetPriceById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemovePrice(int id)
        {
            //_priceService.RemovePrice(id);
        }
    }
}
