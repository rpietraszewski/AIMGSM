using AIMGSM.Data;

namespace AIMGSM.Models
{
    public class Device
    {
        public Guid Id { get; set; }
        public BrandEnum Brand { get; set; }
        public string Model { get; set; }
    }
}
