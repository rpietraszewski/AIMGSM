using AIMGSM.Models;
using AIMGSM.ViewModels;

namespace AIMGSM.Interfaces
{
    public interface IPriceService
    {
        public void AddPrice(PriceVM priceVM, int deviceId, int serviceId);
        public List<PriceVM> GetAllPrices();
        public PriceVM GetPriceById(int id);
        public void RemovePrice(int id);
    }
}
