using AIMGSM.Models;

namespace AIMGSM.Interfaces
{
    public interface IDeviceRepository
    {
        public List<Device> GetAllDevices();
        public Device GetDeviceById(int id);
        public void AddDevice(Device device);
        public void RemoveDevice(int id);
        public void EditDevice(int id);
    }
}
