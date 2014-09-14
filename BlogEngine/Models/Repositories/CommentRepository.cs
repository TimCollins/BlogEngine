using System.Collections.Generic;
using BlogEngine.Models.Entities;

namespace BlogEngine.Models.Repositories
{
    public class CommentRepository
    {
        public List<Comment> GetComments(long postID)
        {
            return new List<Comment>();   
        }
    }
}