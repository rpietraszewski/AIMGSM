using System.ComponentModel.DataAnnotations;

namespace AIMGSM.ViewModels
{
    public class FormVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        [EmailAddress(ErrorMessage = "Niepoprawnie wpisany email")]
        public string? Email { get; set; }
        public string? Topic { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public IFormFile ImageFile { get; set; }
        public string? ImageUrl { get; set; }
    }
}
