using System.Text.Json.Serialization;

namespace BnDapi.Models
{
    public class DuAnImgae
    {
        public int Id { get; set; }
        public string ImageA { get; set; }
        public string ImageB { get; set; }

        [JsonIgnore]
        public Duan Duan { get; set; }
        public int DuanId { get; set; }
    }
}
