using AIMGSM.Data;

namespace AIMGSM.ViewModels
{
    public class ServiceVM
    {
        public string Name { get; set; }
        public int PriceOriginal { get; set; }
        public int SecondPrice { get; set; }
        public BrandEnum Brand { get; set; }
        public string Model { get; set; }
    }
}
