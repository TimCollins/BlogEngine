namespace BlogEngine.Models.Entities
{
    public class Post : BaseEntity
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}