using System.ComponentModel.DataAnnotations;
using BlogEngine.Models.Validation;

namespace BlogEngine.Models.ViewModels
{
    public class AddURLViewModel
    {
        [Required]
        [Url]
        public string OriginalURL { get; set; }

        public bool UseCustomSlug { get; set; }

        [RequiredIfTrue(BooleanPropertyName = "UseCustomSlug", 
            ErrorMessage = "Please provide a custom slug if you opt for one.")]
        public string CustomSlug { get; set; }
    }
}