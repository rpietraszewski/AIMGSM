using AIMGSM.Interfaces;
using AIMGSM.Models;
using AIMGSM.Repositories;
using AIMGSM.ViewModels;
using Microsoft.SqlServer.Server;

namespace AIMGSM.Services
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;
        public FormService(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }
        public void AddForm(FormVM formVM)
        {
            Form form = new Form()
            {
                Name = formVM.Name,
                Email = formVM.Email,
                Description = formVM.Description,
                PhoneNumber = formVM.PhoneNumber,
                ImageUrl = formVM.ImageUrl,
            };
            _formRepository.AddForm(form);
        }

        public List<FormVM> GetAllForms()
        {
            List<Form> list = _formRepository.GetAllForms();
            if (list.Count == 0)
            {
                return new List<FormVM>();
            }
            List<FormVM> result = new List<FormVM>();
            list.ForEach(element =>
            {
                FormVM resultVM = new FormVM()
                {
                    Name = element.Name,
                    Email = element.Email,
                    Description = element.Description,
                    PhoneNumber = element.PhoneNumber,
                    ImageUrl = element.ImageUrl,
                };
                result.Add(resultVM);
            });
            return result;
        }

        public void RemoveForm(int id)
        {
            _formRepository.RemoveForm(id);
        }
    }
}
