using AIMGSM.Models;

namespace AIMGSM.Interfaces
{
    public interface IPriceRepository
    {
        public void AddPrice(Price price);
        public List<Price> GetAllPrices();
        public Price GetPriceById(int id);
        public void RemovePrice(int id);
    }
}
