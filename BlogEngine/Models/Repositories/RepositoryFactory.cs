using BlogEngine.Models.Repositories.Interfaces;

namespace BlogEngine.Models.Repositories
{
    public class RepositoryFactory
    {
        private static IPostRepository _postRepository;

        public static IPostRepository PostRepository
        {
            get { return _postRepository ?? (_postRepository = new PostRepository()); }
            set { _postRepository = value; }
        }
    }
}