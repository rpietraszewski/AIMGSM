using AIMGSM.ViewModels;

namespace AIMGSM.Interfaces
{
    public interface IDeviceService
    {
        public List<DeviceVM> GetAllDevices();
        public DeviceVM GetDeviceById(int id);
        public void AddDevice(DeviceVM deviceVM);
        public void RemoveDevice(int id);
        public void EditDevice(int id);

    }
}
