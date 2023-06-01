using AIMGSM.Models;
using AIMGSM.ViewModels;

namespace AIMGSM.Interfaces
{
    public interface IFormService
    {
        public void AddForm(FormVM formVM);
        public List<FormVM> GetAllForms();
        public void RemoveForm(int id);
        public FormVM GetFormById(int id);
    }
}
