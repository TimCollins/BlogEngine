using System.ComponentModel;

namespace BlogEngine.Models.Entities
{
    public class User : BaseEntity
    {
        public int ID { get; set; }

        [DisplayName("Username")]
        public string Name { get; set; }
        public string Password { get; set; }
    }
}