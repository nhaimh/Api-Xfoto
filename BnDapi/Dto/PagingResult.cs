namespace BnDapi.Dto
{
    public class PagingResult<T>
    {
        public int TotalRows { get; set; }
        public List<T> Data { get; set; }
    }
}
