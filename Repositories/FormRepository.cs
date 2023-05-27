using AIMGSM.Contexts;
using AIMGSM.Interfaces;
using AIMGSM.Models;
using AIMGSM.ViewModels;

namespace AIMGSM.Repositories
{
    public class FormRepository : IFormRepository
    {
        private readonly GlobalContext _context;
        public FormRepository(GlobalContext context)
        {
            _context = context;
        }

        public void AddForm(Form form)
        {
            if (form == new Form())
            {
                return;
            }
            _context.Form.Add(form);
            _context.SaveChanges();
        }

        public List<Form> GetAllForms()
        {
            return _context.Form.OrderBy(x => x.Id).ToList();
        }

        public Form GetFormById(int id)
        {
            return _context.Form.FirstOrDefault(x => x.Id == id);
        }

        public void RemoveForm(int id)
        {
            Form form = _context.Form.FirstOrDefault(y => y.Id == id);
            if (form == new Form())
            {
                return;
            }
            _context.Form.Remove(form);
            _context.SaveChanges();
        }
    }
}
