using AIMGSM.Data;

namespace AIMGSM.ViewModels
{
    public class PriceVM
    {
        public int Id { get; set; }
        public int OriginalPrice { get; set; }
        public int SecondPrice { get; set; }
        public string? Name { get; set; }
        public BrandEnum? Brand { get; set; }
        public string? Model { get; set; }
    }
}
