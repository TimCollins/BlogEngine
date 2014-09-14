namespace BlogEngine.Models.ViewModels
{
    public class PostSummary 
    {
        public long PostID { get; set; }
        public string DateDetails { get; set; }
        public string CategoryName { get; set; }
        public string Summary { get; set; }
        public string Subject { get; set; }
        public long UserID { get; set; }
        public string UserName { get; set; }
    }
}