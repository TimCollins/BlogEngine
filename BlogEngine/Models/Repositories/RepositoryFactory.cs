using BlogEngine.Models.Repositories.Interfaces;

namespace BlogEngine.Models.Repositories
{
    public class RepositoryFactory
    {
        private static IPostRepository _postRepository;
        private static ICategoryRepository _categoryRepository;

        public static IPostRepository PostRepository
        {
            get { return _postRepository ?? (_postRepository = new PostRepository()); }
            set { _postRepository = value; }
        }

        public static ICategoryRepository CategoryRepository
        {
            get { return _categoryRepository ?? (_categoryRepository = new CategoryRepository()); }
            set { _categoryRepository = value; }
        }
    }
}