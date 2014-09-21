using System.Collections.Generic;
using BlogEngine.Models.Entities;
using BlogEngine.Models.ViewModels;

namespace BlogEngine.Models.Repositories.Interfaces
{
    public interface IPostRepository
    {
        List<Post> GetPosts(int count);
        List<PostSummary> GetPostSummaries(int count);
        Post GetPostByID(int id);
    }
}