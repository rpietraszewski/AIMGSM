using AIMGSM.Data;

namespace AIMGSM.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? PreDescription { get; set; }
        public string? Description { get; set; }
        public byte[]? ImageUrl { get; set; }
    }
}
