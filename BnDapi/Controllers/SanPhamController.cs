using BnDapi.Data;
using BnDapi.Dto;
using BnDapi.Models;
using BnDapi.Services.DuAnBLL;
using BnDapi.Services.SanPhamBLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BnDapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamBLL _sanPhamBLL;
        public SanPhamController(ISanPhamBLL sanPhamBLL)
        {
            _sanPhamBLL = sanPhamBLL;
        }
        [HttpGet]
        public async Task<ActionResult<List<SanPham>>> GetAll()
        {
            var result = await _sanPhamBLL.GetAll();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpGet("detail/id")]
        public async Task<ActionResult<SanPhamImage>> GetById(int id)
        {
            var result = await _sanPhamBLL.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost("detail/getall")]
        public async Task<ActionResult<PagingResult<SanPhamImage>>> GetSPdetail(SanPhamPaging paging)
        {
            var result = await _sanPhamBLL.GetSPdetail(paging);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("detail"), Authorize]
        public async Task<ActionResult<List<SanPhamImage>>> CreateImage(SanPhamImage sanPhamImage)
        {
            try
            {
                await _sanPhamBLL.CreateImage(sanPhamImage);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("detail/id"), Authorize]
        public async Task<ActionResult<List<SanPhamImage>>> DeleteImgae(int id)
        {
            try
            {
                await _sanPhamBLL.DeleteImgae(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut("detail"), Authorize]
        public async Task<ActionResult<List<SanPhamImage>>> UpdateImage([FromBody] SanPhamImage request)
        {
            try
            {
                await _sanPhamBLL.UpdateImage(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
