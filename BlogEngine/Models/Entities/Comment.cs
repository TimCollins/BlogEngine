namespace BlogEngine.Models.Entities
{
    public class Comment : BaseEntity
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public long PostID { get; set; }
    }
}