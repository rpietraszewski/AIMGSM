using AIMGSM.Data;

namespace AIMGSM.ViewModels
{
    public class DeviceVM
    {
        public int Id { get; set; }
        public BrandEnum? Brand { get; set; }
        public string? Model { get; set; }
        public TypeEnum? Type { get; set; }
        public IFormFile ImageFile { get; set; }
        public string? ImageUrl { get; set; }
    }
}
