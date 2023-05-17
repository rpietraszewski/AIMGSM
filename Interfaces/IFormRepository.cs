using AIMGSM.Models;

namespace AIMGSM.Interfaces
{
    public interface IFormRepository
    {
        public void AddForm(Form form);
        public List<Form> GetAllForms();
        public void RemoveForm(int id);
    }
}
