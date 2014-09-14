namespace BlogEngine.Models.Entities
{
    public class Post : BaseEntity
    {
        public long ID { get; set; }
        public long CategoryID { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}