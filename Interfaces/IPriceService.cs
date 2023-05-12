using AIMGSM.Data;
using AIMGSM.Models;
using AIMGSM.ViewModels;

namespace AIMGSM.Interfaces
{
    public interface IPriceService
    {
        public void AddPrice(PriceAddVM priceAddVM);
        public List<PriceVM> GetAllPrices();
        public PriceVM GetPriceById(int id);
        public void RemovePrice(int id);
        public List<PriceVM> GetAllPricesByBrand(BrandEnum Brand);
        public List<PriceVM> GetAllPricesByType(TypeEnum Type);
    }
}
