using Chefer.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chefer.API.Context
{
    public class CheferContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ERHAN\\SQLEXPRESS; database=CheferDb; integrated security=true; trustServerCertificate=true");
        }



        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
