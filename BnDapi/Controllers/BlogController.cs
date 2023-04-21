using BnDapi.Data;
using BnDapi.Dto;
using BnDapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net.NetworkInformation;

namespace BnDapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly DataContext _context;
        public BlogController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("getall"),Authorize]
        public async Task<ActionResult<PagingResult<Blog>>> GetAll(BlogPaging paging)
        {
            PagingResult<Blog> result = new();
            var query = _context.Blog.Where(x => (string.IsNullOrEmpty(paging.KeyWord) || x.Title.Contains(paging.KeyWord))); // Query ra những row phù hợp điều kiện
            result.TotalRows = query.Count(); // Đếm tổng row phù hợp
            result.Data = query.Skip(paging.pageSize * (paging.pageIndex - 1)).Take(paging.pageSize).ToList(); // Lấy row theo paging
            return Ok(result);
        }
        [HttpGet("get/id")]
        public async Task<ActionResult<Blog>> GetByIdBlog(int id)
        {
            var blo = await _context.Blog.Where(c => c.Id == id).SingleAsync();
            return blo;
        }
        [HttpPost(), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Blog>>> CreateBlog(Blog blog)
        {
            _context.Blog.Add(blog);
            await _context.SaveChangesAsync();


            return Ok(blog);
        }
        [HttpDelete("id"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Blog>>> DeleteBlog(int id)
        {
            var blog = await _context.Blog.FindAsync(id);
            _context.Blog.Remove(blog);
            await _context.SaveChangesAsync();
            return Ok("Remove success");
        }
        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<Blog>>> UpdateBlog([FromBody] Blog request)
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

            return Ok(blog);
        }

    }
}
