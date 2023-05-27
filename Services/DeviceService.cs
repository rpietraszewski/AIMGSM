using AIMGSM.Interfaces;
using AIMGSM.Models;
using AIMGSM.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AIMGSM.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        public DeviceService(IDeviceRepository deviceRepository) 
        { 
            _deviceRepository = deviceRepository;
        }

        public void AddDevice(DeviceVM deviceVM)
        {
            Device device = new Device()
            {
                Id = deviceVM.Id,
                Brand = deviceVM.Brand,
                Model = deviceVM.Model,
                Type= deviceVM.Type,
                ImageUrl = deviceVM.ImageUrl,
            };
            _deviceRepository.AddDevice(device);
        }

        public void EditDevice(int id)
        {
            throw new NotImplementedException();
        }

        public List<DeviceVM> GetAllDevices()
        {
            List<Device> list = _deviceRepository.GetAllDevices();
            if (list.Count == 0)
            {
                return new List<DeviceVM>();
            }
            List<DeviceVM> result = new List<DeviceVM>();
            list.ForEach(element =>
            {
                DeviceVM resultVM = new DeviceVM()
                {
                    Id = element.Id,
                    Brand = element.Brand,
                    Model = element.Model,
                    Type = element.Type,
                    ImageUrl = element.ImageUrl
                };
                result.Add(resultVM);
            });
            return result;
        }

        public DeviceVM GetDeviceById(int id)
        {
            Device device = _deviceRepository.GetDeviceById(id);
            return new DeviceVM()
            {
                Id = device.Id,
                Brand = device.Brand,
                Model = device.Model,
                Type = device.Type,
                ImageUrl = device.ImageUrl,
            };
        }

        public void RemoveDevice(int id)
        {
            _deviceRepository.RemoveDevice(id);
        }
    }
}
