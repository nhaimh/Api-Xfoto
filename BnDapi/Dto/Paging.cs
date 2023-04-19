namespace BnDapi.Dto
{
    public class Paging
    {
        public int pageSize { get; set; }
        public int pageIndex { get; set; }
    }
    public class BlogPaging : Paging
    {
        public int Status { get; set; }
        public string KeyWord { get; set; }
    }
    public class DuAnPaging : Paging
    {
        public int Status { get; set; }
        public string KeyWord { get; set; }
    }
    public class SanPhamPaging : Paging
    {
        public int Status { get; set; }
        public string KeyWord { get; set; }
    }
    public class UserPaging : Paging
    {
        public int Status { get; set; }
        public string KeyWord { get; set; }
    }
}
