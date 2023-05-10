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
        public void AddPrice(PriceAddVM priceAddVM)
        {
            Price obj = new Price()
            {
                Id = priceAddVM.Id,
                OriginalPrice = priceAddVM.OriginalPrice,
                SecondPrice = priceAddVM.SecondPrice,
                DeviceId= priceAddVM.DeviceId,
                ServiceId= priceAddVM.ServiceId,
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
                DeviceVM device = _deviceService.GetDeviceById(element.DeviceId);
                ServiceVM service = _serviceService.GetServiceById(element.ServiceId);
                PriceVM resultVM = new PriceVM()
                {
                    Id = element.Id,
                    OriginalPrice = element.OriginalPrice,
                    SecondPrice = element.SecondPrice,
                    Name = service.Name,
                    Type = service.Type,
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
