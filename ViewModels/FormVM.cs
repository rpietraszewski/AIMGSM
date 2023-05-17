using System.ComponentModel.DataAnnotations;

namespace AIMGSM.ViewModels
{
    public class FormVM
    {
        public string? Name { get; set; }
        [EmailAddress(ErrorMessage = "Niepoprawnie wpisany email")]
        public string? Email { get; set; }
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
        public byte[]? ImageUrl { get; set; }
    }
}
