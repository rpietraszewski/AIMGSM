namespace AIMGSM.Models
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float PriceOriginal { get; set; }
        public Guid DeviceId { get; set; }
        public float PriceFake { get; set; }
    }
}
