using AIMGSM.Data;

namespace AIMGSM.Models
{
    public class Device
    {
        public int Id { get; set; }
        public BrandEnum? Brand { get; set; }
        public string? Model { get; set; }
        public TypeEnum? Type { get; set; }
    }
}
