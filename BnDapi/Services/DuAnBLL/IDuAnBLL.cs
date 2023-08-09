using BnDapi.Dto;
using BnDapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BnDapi.Services.DuAnBLL
{
    public interface IDuAnBLL
    {
        Task<ActionResult<List<Duan>>> GetAll();
        Task<ActionResult<Duan>> GetById(int id);
        Task<ActionResult<PagingResult<DuAnImgae>>> GetImage(DuAnPaging paging);
        Task<ActionResult<DuAnImgae>> GetByIdimgae(int id);
        Task<DuAnImgae> CreateImage(DuAnImgae duAnImgae);
        Task<DuAnImgae> DeleteImgae(int id);
        Task<DuAnImgae> UpdateImage([FromBody] DuAnImgae request);
    }
}
