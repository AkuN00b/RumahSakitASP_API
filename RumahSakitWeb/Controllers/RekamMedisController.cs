using Microsoft.AspNetCore.Mvc;
using RumahSakitWeb.Data;
using RumahSakitWeb.Models;

namespace RumahSakitWeb.Controllers
{
    public class RekamMedisController : Controller
    {
        private readonly ApplicationDbContext _db;
        public RekamMedisController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ICollection<RekamMedis> dataRekamMedis = _db.TableRekamMedis.ToList();
            return View(dataRekamMedis);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RekamMedis rekammedis)
        {
            if (ModelState.IsValid)
            {
                _db.TableRekamMedis.Add(rekammedis);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rekammedis);
        }

        public IActionResult Edit(int id)
        {
            RekamMedis rekammedis = _db.TableRekamMedis.Find(id);
            return View(rekammedis);
        }

        [HttpPost]
        public IActionResult Edit(RekamMedis rekammedis)
        {
            if (ModelState.IsValid)
            {
                _db.TableRekamMedis.Update(rekammedis);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rekammedis);
        }

        public async Task<IActionResult> Delete(int id)
        {
            RekamMedis rekammedis = _db.TableRekamMedis.Find(id);
            _db.TableRekamMedis.Remove(rekammedis);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            RekamMedis rekammedis = _db.TableRekamMedis.Find(id);
            return View(rekammedis);
        }
    }
}
