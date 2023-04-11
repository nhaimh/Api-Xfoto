using BnDapi.Data;
using BnDapi.Dto;
using BnDapi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BnDapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuAnController : ControllerBase
    {
        private readonly DataContext _context;
        public DuAnController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Duan>>> GetAll()
        {
            var duans = await _context.Duans.Include(c => c.DuAnImgae).ToListAsync();
            return duans;
        }
        [HttpGet("id")]
        public async Task<ActionResult<Duan>> GetById(int id)
        {
            var duan = await _context.Duans
                .Where(c => c.Id == id)
                .Include(c => c.DuAnImgae)
                .SingleAsync();
            return duan;
        }
        [HttpPost("getall")]
        public async Task<ActionResult<PagingResult<DuAnImgae>>> GetImage(DuAnPaging paging)
        {
            PagingResult<DuAnImgae> result = new();
            var query = _context.DuAnImgae.Where(x => (string.IsNullOrEmpty(paging.KeyWord) || x.ImageA.Contains(paging.KeyWord))); // Query ra những row phù hợp điều kiện
            result.TotalRows = query.Count(); // Đếm tổng row phù hợp
            result.Data = query.Skip(paging.pageSize * (paging.pageIndex - 1)).Take(paging.pageSize).ToList(); // Lấy row theo paging
            return Ok(result);
        }
        [HttpGet("DuAnImage/id")]
        public async Task<ActionResult<DuAnImgae>> GetByIdimgae(int id)
        {
            var blog = await _context.DuAnImgae.Where(_x => _x.Id == id).SingleAsync();
            return blog;
        }

        [HttpPost("DuAnImage"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<DuAnImgae>>> CreateImage(DuAnImgae duAnImgae)
        {
            _context.DuAnImgae.Add(duAnImgae);
            await _context.SaveChangesAsync();
            return Ok(duAnImgae);
        }
        [HttpDelete("DuAnImage/id"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<DuAnImgae>>> DeleteImgae(int id)
        {
            var blog = await _context.DuAnImgae.FindAsync(id);
            _context.DuAnImgae.Remove(blog);
            await _context.SaveChangesAsync();
            return Ok("Remove success");
        }
        [HttpPut("DuAnImage"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<DuAnImgae>>> UpdateImage([FromBody] DuAnImgae request)
        {
            var imgae = await _context.DuAnImgae.FindAsync(request.Id);
            imgae.ImageA = request.ImageA;
            imgae.ImageB = request.ImageB;
            imgae.DuanId = request.DuanId;

            await _context.SaveChangesAsync();

            return Ok(imgae);
        }
    }
}
