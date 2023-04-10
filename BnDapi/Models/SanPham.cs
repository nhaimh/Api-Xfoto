namespace BnDapi.Models
{
    public class SanPham
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<SanPhamImage> SanPhamImages { get; set; }
    }
}
