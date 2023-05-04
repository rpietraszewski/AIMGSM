using AIMGSM.Data;

namespace AIMGSM.ViewModels
{
    public class PriceAddVM
    {
        public int Id { get; set; }
        public int OriginalPrice { get; set; }
        public int SecondPrice { get; set; }
        public int DeviceId { get; set; }
        public int ServiceId { get; set; }
    }
}
