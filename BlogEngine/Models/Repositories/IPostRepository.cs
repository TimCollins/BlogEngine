using System.Collections.Generic;
using BlogEngine.Models.Entities;

namespace BlogEngine.Models.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetPosts(int count);
        void AddPost(Post post);
    }
}