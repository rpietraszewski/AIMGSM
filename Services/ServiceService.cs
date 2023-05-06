using AIMGSM.Interfaces;
using AIMGSM.Models;
using AIMGSM.Repositories;
using AIMGSM.ViewModels;

namespace AIMGSM.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository= serviceRepository;
        }
        public void AddService(ServiceVM serviceVM)
        {
            Service service = new Service()
            {
                Id = serviceVM.Id,
                Name = serviceVM.Name,
                Type= serviceVM.Type,
            };
            _serviceRepository.AddService(service);
        }

        public void EditService(int id)
        {
            //Service service = _serviceRepository.GetServiceById(id);
            //ServiceVM serviceVM = _map.Map(service);
            //{
            //    Id = service.Id,
            //    Name = service.Name,
            //};
            //_serviceRepository.EditService(service);
        }

        public List<ServiceVM> GetAllServices()
        {
            List<Service> list = _serviceRepository.GetAllServices();
            if (list.Count == 0)
            {
                return new List<ServiceVM>();
            }
            List<ServiceVM> result = new List<ServiceVM>();
            list.ForEach(element =>
            {
                ServiceVM resultVM = new ServiceVM()
                {
                    Id = element.Id,
                    Name = element.Name,
                    Type = element.Type,
                };
                result.Add(resultVM);
            });
            return result;
        }

        public ServiceVM GetServiceById(int id)
        {
            Service service = _serviceRepository.GetServiceById(id);
            return new ServiceVM()
            {
                Id = service.Id,
                Name = service.Name,
                Type = service.Type,
            };
        }

        public void RemoveService(int id)
        {
            _serviceRepository.RemoveService(id);
        }
    }
}
