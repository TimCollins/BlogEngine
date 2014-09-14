using System.Collections.Generic;
using BlogEngine.Models.Entities;

namespace BlogEngine.Models.Repositories
{
    /// <summary>
    /// An alternative repository implementation not using a generic interface (yet)
    /// </summary>
    public class PostRepository
    {
        public List<Post> GetPosts(int count)
        {
            return new List<Post>();
        }
    }
}