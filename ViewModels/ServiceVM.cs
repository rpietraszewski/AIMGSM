using AIMGSM.Data;

namespace AIMGSM.ViewModels
{
    public class ServiceVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float PriceOriginal { get; set; }
        public float PriceFake { get; set; }
        public BrandEnum Brand { get; set; }
        public string Model { get; set; }
    }
}
