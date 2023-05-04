using AIMGSM.Contexts;
using AIMGSM.Interfaces;
using AIMGSM.Models;

namespace AIMGSM.Repositories
{
    public class PriceRepository : IPriceRepository
    {
        private readonly GlobalContext _context;
        public PriceRepository(GlobalContext context)
        {
            _context = context;
        }
        public void AddPrice(Price price)
        {
            _context.Price.Add(price);
            _context.SaveChanges();
        }

        public List<Price> GetAllPrices()
        {
            return _context.Price.OrderBy(p=>p.Id).ToList();
        }

        public Price GetPriceById(int id)
        {
            return _context.Price.FirstOrDefault(y => y.Id == id);
        }

        public void RemovePrice(int id)
        {
            Price price = _context.Price.FirstOrDefault(y => y.Id == id);
            if (price == null)
            {
                return;
            }
            _context.Price.Remove(price);
            _context.SaveChanges();
        }
    }
}
