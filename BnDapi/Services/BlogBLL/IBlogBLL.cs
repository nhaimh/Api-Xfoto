using BnDapi.Dto;
using BnDapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BnDapi.Services.BlogBLL
{
    public interface IBlogBLL
    {
        Task<ActionResult<PagingResult<Blog>>> GetAll(BlogPaging paging);
        Task<ActionResult<Blog>> GetByIdBlog(int id);
        Task<Blog> CreateBlog(Blog blog);
        Task<Blog> DeleteBlog(int id);
        Task<Blog> UpdateBlog([FromBody] Blog request);
    }
}
