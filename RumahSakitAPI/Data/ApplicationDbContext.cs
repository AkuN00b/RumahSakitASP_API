using Microsoft.EntityFrameworkCore;
using RumahSakitAPI.Models;

namespace RumahSakitAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Dokter> TableDokter { get; set; }
		public DbSet<Pasien> TablePasien { get; set; }
	}
}
