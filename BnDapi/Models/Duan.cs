using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BnDapi.Models
{
    public class Duan
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string ImageB { get; set; } = string.Empty;
        [Column(TypeName = "jsonb")]
        [JsonIgnore]
        public List<string> ListImg { get; set; }

        public List<DuAnImgae> DuAnImgae { get; set; }
    }
}
