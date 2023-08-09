using BnDapi.Dto;
using BnDapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BnDapi.Services.SanPhamBLL
{
    public interface ISanPhamBLL
    {
        Task<ActionResult<List<SanPham>>> GetAll();
        Task<ActionResult<SanPhamImage>> GetById(int id);
        Task<ActionResult<PagingResult<SanPhamImage>>> GetSPdetail(SanPhamPaging paging);
        Task<SanPhamImage> CreateImage(SanPhamImage sanPhamImage);
        Task<SanPhamImage> DeleteImgae(int id);
        Task<SanPhamImage> UpdateImage([FromBody] SanPhamImage request);
    }
}
