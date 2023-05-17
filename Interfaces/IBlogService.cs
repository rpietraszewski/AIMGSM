using AIMGSM.Models;
using AIMGSM.ViewModels;

namespace AIMGSM.Interfaces
{
    public interface IBlogService
    {
        public void AddBlog(BlogVM blogVM);
        public void EditBlog(BlogVM blogVM);
        public List<BlogVM> GetAllBlogs();
        public void RemoveBlog(int id);
    }
}
