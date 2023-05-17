using AIMGSM.Contexts;
using AIMGSM.Interfaces;
using AIMGSM.Models;

namespace AIMGSM.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly GlobalContext _context;
        public BlogRepository(GlobalContext context)
        {
            _context = context;
        }

        public void AddBlog(Blog blog)
        {
            if (blog == new Blog())
            {
                return;
            }
            _context.Blog.Add(blog);
            _context.SaveChanges();
        }

        public void EditBlog(Blog blog)
        {
            if(blog == new Blog())
            {
                return;
            }
            _context.Blog.Update(blog);
            _context.SaveChanges();
        }

        public List<Blog> GetAllBlogs()
        {
            return _context.Blog.OrderBy(x => x.Id).ToList();
        }

        public void RemoveBlog(int id)
        {
            Blog blog = _context.Blog.FirstOrDefault(y => y.Id == id);
            if (blog == new Blog())
            {
                return;
            }
            _context.Blog.Remove(blog);
            _context.SaveChanges();
        }
    }
}
