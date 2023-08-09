using BnDapi.Data;
using BnDapi.Dto;
using BnDapi.Models;
using BnDapi.Services.BlogBLL;
using BnDapi.Services.DuAnBLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;

namespace BnDapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuAnController : ControllerBase
    {
        private readonly IDuAnBLL _duAnBLL;
        public DuAnController(IDuAnBLL duAnBLL)
        {
            _duAnBLL = duAnBLL;
        }
        [HttpGet]
        public async Task<ActionResult<List<Duan>>> GetAll()
        {
            var result = await _duAnBLL.GetAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("id")]
        public async Task<ActionResult<Duan>> GetById(int id)
        {
            var result = await _duAnBLL.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost("getall")]
        public async Task<ActionResult<PagingResult<DuAnImgae>>> GetImage(DuAnPaging paging)
        {
            var result = await _duAnBLL.GetImage(paging);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("DuAnImage/id")]
        public async Task<ActionResult<DuAnImgae>> GetByIdimgae(int id)
        {
            var result = await _duAnBLL.GetByIdimgae(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("DuAnImage"), Authorize]
        public async Task<ActionResult<List<DuAnImgae>>> CreateImage(DuAnImgae duAnImgae)
        {
            try
            {
                await _duAnBLL.CreateImage(duAnImgae);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("DuAnImage/id"), Authorize]
        public async Task<ActionResult<List<DuAnImgae>>> DeleteImgae(int id)
        {
            var deletedBlog = await _duAnBLL.DeleteImgae(id);
            if (deletedBlog == null)
            {
                return NotFound("Image not found");
            }
            return Ok("Remove success");
        }
        [HttpPut("DuAnImage"), Authorize]
        public async Task<ActionResult<List<DuAnImgae>>> UpdateImage([FromBody] DuAnImgae request)
        {
            try
            {
                await _duAnBLL.UpdateImage(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
