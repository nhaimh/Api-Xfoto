using BnDapi.Data;
using BnDapi.Dto;
using BnDapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BnDapi.Services.SanPhamBLL
{
    public class SanPhamBLL : ISanPhamBLL
    {
        private readonly DataContext _context;
        public SanPhamBLL(DataContext context)
        {
            _context = context;
        }
        public async Task<SanPhamImage> CreateImage(SanPhamImage sanPhamImage)
        {
            _context.SanPhamImage.Add(sanPhamImage);
            await _context.SaveChangesAsync();

            return sanPhamImage;
        }

        public async Task<SanPhamImage> DeleteImgae(int id)
        {
            var imgae = await _context.SanPhamImage.FindAsync(id);
            if (imgae == null)
            {
                return null;
            }
            _context.SanPhamImage.Remove(imgae);
            await _context.SaveChangesAsync();
            return imgae;
        }

        public async Task<ActionResult<List<SanPham>>> GetAll()
        {
            var sanphams = await _context.SanPham
                .Include(c => c.SanPhamImages)
                .ToListAsync();
            return sanphams;
        }

        public async Task<ActionResult<SanPhamImage>> GetById(int id)
        {
            var sanpham = await _context.SanPhamImage
                 .Where(c => c.Id == id)
                 .SingleAsync();
            return sanpham;
        }

        public async Task<ActionResult<PagingResult<SanPhamImage>>> GetSPdetail(SanPhamPaging paging)
        {
            PagingResult<SanPhamImage> result = new();
            var query = _context.SanPhamImage.Where(x => (string.IsNullOrEmpty(paging.KeyWord) || x.Description.Contains(paging.KeyWord))); // Query ra những row phù hợp điều kiện
            result.TotalRows = query.Count(); // Đếm tổng row phù hợp
            result.Data = query.Skip(paging.pageSize * (paging.pageIndex - 1)).Take(paging.pageSize).ToList(); // Lấy row theo paging
            return result;
        }

        public async Task<SanPhamImage> UpdateImage([FromBody] SanPhamImage request)
        {
            var imgae = await _context.SanPhamImage.FindAsync(request.Id);
            imgae.Description = request.Description;
            imgae.ImageA = request.ImageA;
            imgae.ImageB = request.ImageB;
            imgae.SanPhamId = request.SanPhamId;

            await _context.SaveChangesAsync();

            return imgae;
        }
    }
}
