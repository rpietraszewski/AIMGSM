using AIMGSM.Models;

namespace AIMGSM.Interfaces
{
    public interface IBlogRepository
    {
        public void AddBlog(Blog blog);
        public void EditBlog(Blog blog);
        public List<Blog> GetAllBlogs();
        public void RemoveBlog(int id);
    }
}
