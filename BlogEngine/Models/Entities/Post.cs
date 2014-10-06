using System.ComponentModel.DataAnnotations;

namespace BlogEngine.Models.Entities
{
    public class Post : BaseEntity
    {
        public long ID { get; set; }

        [Display(Name="Category")]
        public long CategoryID { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }
    }
}