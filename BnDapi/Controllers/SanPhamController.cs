using BnDapi.Data;
using BnDapi.Dto;
using BnDapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BnDapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly DataContext _context;
        public SanPhamController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<SanPham>>> GetAll()
        {
            var sanphams = await _context.SanPham
                .Include(c => c.SanPhamImages)
                .ToListAsync();
            return sanphams;
        }
        [HttpGet("detail/id")]
        public async Task<ActionResult<SanPhamImage>> GetById(int id)
        {
            var sanpham = await _context.SanPhamImage
                .Where(c => c.Id == id)
                .SingleAsync();
            return sanpham;
        }
        [HttpPost("detail/getall")]
        public async Task<ActionResult<PagingResult<SanPhamImage>>> GetSPdetail(SanPhamPaging paging)
        {
            PagingResult<SanPhamImage> result = new();
            var query = _context.SanPhamImage.Where(x => (string.IsNullOrEmpty(paging.KeyWord) || x.ImageA.Contains(paging.KeyWord))); // Query ra những row phù hợp điều kiện
            result.TotalRows = query.Count(); // Đếm tổng row phù hợp
            result.Data = query.Skip(paging.pageSize * (paging.pageIndex - 1)).Take(paging.pageSize).ToList(); // Lấy row theo paging
            return Ok(result);
        }

        [HttpPost("detail")]
        public async Task<ActionResult<List<SanPhamImage>>> CreateImage(SanPhamImage sanPhamImage)
        {
            _context.SanPhamImage.Add(sanPhamImage);
            await _context.SaveChangesAsync();

            return Ok(sanPhamImage);
        }
        [HttpDelete("detail/id")]
        public async Task<ActionResult<List<SanPhamImage>>> DeleteImgae(int id)
        {
            var blog = await _context.SanPhamImage.FindAsync(id);
            _context.SanPhamImage.Remove(blog);
            await _context.SaveChangesAsync();
            return Ok("Remove success");
        }
        [HttpPut("detail")]
        public async Task<ActionResult<List<SanPhamImage>>> UpdateImage([FromBody] SanPhamImage request)
        {
            var imgae = await _context.SanPhamImage.FindAsync(request.Id);
            imgae.Description = request.Description;
            imgae.ImageA = request.ImageA;
            imgae.ImageB = request.ImageB;
            imgae.SanPhamId = request.SanPhamId;

            await _context.SaveChangesAsync();

            return Ok(imgae);
        }

    }
}
