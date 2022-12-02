using Microsoft.EntityFrameworkCore;
using RumahSakitWeb.Models;

namespace RumahSakitWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected ApplicationDbContext()
        {
        }
        
        public DbSet<Dokter> TableDokter { get; set; }
        public DbSet<Pasien> TablePasien { get; set; }
        public DbSet<RekamMedis> TableRekamMedis { get; set; }
    }
}
