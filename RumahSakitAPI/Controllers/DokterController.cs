using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RumahSakitAPI.Models;
using RumahSakitAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace RumahSakitAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DokterController : ControllerBase
	{
		private readonly ApplicationDbContext _db;

		public DokterController(ApplicationDbContext db)
		{
			_db = db;
		}

		[HttpGet("GetAllDataDokter")]
		public async Task<ActionResult<IEnumerable<Dokter>>> GetAllDataDokter()
		{
			IEnumerable<Dokter> dataDokter = await _db.TableDokter.ToListAsync();

			return Ok(dataDokter);
		}

		[HttpPost("CreateDataDokter")]
		public async Task<ActionResult> CreateDataDokter(Dokter obj)
		{
			_db.TableDokter.Add(obj);
			_db.SaveChangesAsync();

			return Ok();
		}
	}
}
