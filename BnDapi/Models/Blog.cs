using System.Text.Json.Serialization;

namespace BnDapi.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DemoDescription { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Image { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }
        public int AtuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
