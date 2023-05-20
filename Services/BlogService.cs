using AIMGSM.Interfaces;
using AIMGSM.Models;
using AIMGSM.Repositories;
using AIMGSM.ViewModels;

namespace AIMGSM.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public void AddBlog(BlogVM blogVM)
        {
            Blog blog = new Blog()
            {
                Title = blogVM.Title,
                PreDescription = blogVM.PreDescription,
                Description = blogVM.Description,
                ImageUrl = blogVM.ImageUrl,
            };
            _blogRepository.AddBlog(blog);
        }

        public void EditBlog(BlogVM blogVM)
        {
            Blog blog = new Blog()
            {
                Title = blogVM.Title,
                PreDescription = blogVM.PreDescription,
                Description = blogVM.Description,
                ImageUrl = blogVM.ImageUrl,
            };
            _blogRepository.EditBlog(blog);
        }

        public List<BlogVM> GetAllBlogs()
        {
            List<Blog> list = _blogRepository.GetAllBlogs();
            if (list.Count == 0)
            {
                return new List<BlogVM>();
            }
            List<BlogVM> result = new List<BlogVM>();
            list.ForEach(element =>
            {
                BlogVM resultVM = new BlogVM()
                {
                    Title = element.Title,
                    PreDescription = element.PreDescription,
                    Description = element.Description,
                    ImageUrl = element.ImageUrl,
                };
                result.Add(resultVM);
            });
            return result;
        }

        public void RemoveBlog(int id)
        {
            _blogRepository.RemoveBlog(id);
        }
    }
}
