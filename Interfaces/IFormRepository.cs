using AIMGSM.Models;

namespace AIMGSM.Interfaces
{
    public interface IFormRepository
    {
        public void AddForm(Form form);
        public List<Form> GetAllForms();
        public Form GetFormById(int id);
        public void RemoveForm(int id);
    }
}
