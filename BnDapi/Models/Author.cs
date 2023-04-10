namespace BnDapi.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Blog> Blog { get; set; }
    }
}
