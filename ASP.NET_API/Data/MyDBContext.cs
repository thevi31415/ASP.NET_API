using ASP.NET_API.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_API.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {



        }
        public DbSet<HangHoa> hangHoas { get; set; }
        public DbSet<Loai> loais { get; set; }
        public DbSet<NguoiDung> nguoiDungs { get; set; }

    }
}
