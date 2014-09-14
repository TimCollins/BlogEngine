namespace BlogEngine.Models.Entities
{
    public class Comment : BaseEntity
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int PostID { get; set; }
    }
}