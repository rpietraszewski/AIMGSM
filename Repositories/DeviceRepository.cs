using AIMGSM.Contexts;
using AIMGSM.Interfaces;
using AIMGSM.Models;

namespace AIMGSM.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly GlobalContext _context;
        public DeviceRepository(GlobalContext context)
        {
            _context = context;
        }
        
        public List<Device> GetAllDevices() 
        {
            return _context.Device.OrderBy(x => x.Id).ToList();
        }

        public Device GetDeviceById(int id)
        {
            return _context.Device.FirstOrDefault(x => x.Id == id);
        }
        public void AddDevice(Device device)
        {
            if(device == new Device()) 
            {
                return;
            }
            _context.Device.Add(device);
            _context.SaveChanges();
        }

        public void RemoveDevice(int id)
        {
            Device device= _context.Device.FirstOrDefault(y => y.Id == id);
            if (device == new Device())
            {
                return;
            }
            _context.Device.Remove(device);
            _context.SaveChanges();
        }
        public void EditDevice(int id)
        {
            Device device = _context.Device.FirstOrDefault(y => y.Id == id);
            if (device == null)
            {
                return;
            }
            _context.Device.Update(device);
            _context.SaveChanges();
        }
    }
}
