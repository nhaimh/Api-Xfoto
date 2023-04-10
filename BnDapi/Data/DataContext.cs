using BnDapi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BnDapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Duan> Duans { get; set; }
        public DbSet<SanPham> SanPham { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<SanPhamImage> SanPhamImage { get; set; }
        public DbSet<DuAnImgae> DuAnImgae { get; set; }
        public DbSet<User> Users { get; set; }
    }
    
}
