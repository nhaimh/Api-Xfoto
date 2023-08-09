using BnDapi.Data;
using BnDapi.Dto;
using BnDapi.Models;
using BnDapi.Services.BlogBLL;
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

        private readonly IBlogBLL _blogBLL;
        public BlogController(IBlogBLL blogBLL)
        {
            _blogBLL = blogBLL;
        }

        [HttpPost("getall")]
        public async Task<ActionResult<PagingResult<Blog>>> GetAll(BlogPaging paging)
        {
            var result = await _blogBLL.GetAll(paging);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("get/id"), Authorize]
        public async Task<ActionResult<Blog>> GetByIdBlog(int id)
        {
            var result = await _blogBLL.GetByIdBlog(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost(), Authorize]
        public async Task<ActionResult<List<Blog>>> CreateBlog(Blog blog)
        {
            try
            {
                await _blogBLL.CreateBlog(blog);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        [HttpDelete("id"), Authorize]
        public async Task<ActionResult<List<Blog>>> DeleteBlog(int id)
        {
            {
                var deletedBlog = await _blogBLL.DeleteBlog(id);
                if (deletedBlog == null)
                {
                    return NotFound("Blog not found");
                }
                return Ok("Remove success");
            }
        }
        [HttpPut, Authorize]
        public async Task<ActionResult<List<Blog>>> UpdateBlog([FromBody] Blog request)
        {
            try
            {
                await _blogBLL.UpdateBlog(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
