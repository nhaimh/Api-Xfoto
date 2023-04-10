using System.Text.Json.Serialization;

namespace BnDapi.Models
{
    public class SanPhamImage
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string ImageA { get; set; }
        public string ImageB { get; set; }

        [JsonIgnore]
        public SanPham SanPham { get; set; }
        public int SanPhamId { get; set; }
    }
}
