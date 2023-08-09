using BnDapi.Data;
using BnDapi.Dto;
using BnDapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BnDapi.Services.BlogBLL
{
    public class BlogBLL : IBlogBLL
    {
        private readonly DataContext _context;
        public BlogBLL(DataContext context)
        {
            _context = context;
        }
        public async Task<Blog> CreateBlog(Blog blog)
        {

            _context.Blog.Add(blog);
            await _context.SaveChangesAsync();

            return blog;
        }

        public async Task<Blog> DeleteBlog(int id)
        {
            var blog = await _context.Blog.FindAsync(id);
            if (blog == null)
            {
                return null;
            }
            _context.Blog.Remove(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<ActionResult<PagingResult<Blog>>> GetAll(BlogPaging paging)
        {
            PagingResult<Blog> result = new();
            var query = _context.Blog.Where(x => (string.IsNullOrEmpty(paging.KeyWord) || x.Title.Contains(paging.KeyWord))); // Query ra những row phù hợp điều kiện
            result.TotalRows = query.Count(); // Đếm tổng row phù hợp
            result.Data = query.Skip(paging.pageSize * (paging.pageIndex - 1)).Take(paging.pageSize).ToList(); // Lấy row theo paging
            return result;
        }

        public async Task<ActionResult<Blog>> GetByIdBlog(int id)
        {
            var blo = await _context.Blog.Where(c => c.Id == id).SingleAsync();
            return blo;
        }

        public async Task<Blog> UpdateBlog([FromBody] Blog request)
        {
            var blog = await _context.Blog.FindAsync(request.Id);
            blog.Title = request.Title;
            blog.DemoDescription = request.DemoDescription;
            blog.Description = request.Description;
            blog.CreatedDate = request.CreatedDate;
            blog.Image = request.Image;
            blog.AtuthorId = request.AtuthorId;
            blog.AuthorName = request.AuthorName;

            await _context.SaveChangesAsync();

            return blog;
        }
    }
}
