using System.ComponentModel.DataAnnotations;

namespace BlogEngine.Models.Entities
{
    public class Post : BaseEntity
    {
        public long ID { get; set; }

        [Display(Name="Category")]
        public long CategoryID { get; set; }

        [Required(ErrorMessage = "The subject field is required.")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "The body field is required.")]
        public string Body { get; set; }
    }
}