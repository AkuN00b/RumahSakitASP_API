using Microsoft.AspNetCore.Mvc;
using RumahSakitWeb.Data;
using RumahSakitWeb.Models;

namespace RumahSakitWeb.Controllers
{
    public class PasienController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PasienController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ICollection<Pasien> dataPasien = _db.TablePasien.ToList();
            return View(dataPasien);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pasien pasien)
        {
            if (ModelState.IsValid)
            {
                _db.TablePasien.Add(pasien);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pasien);
        }

        public IActionResult Edit(int id)
        {
            Pasien pasien = _db.TablePasien.Find(id);
            return View(pasien);
        }

        [HttpPost]
        public IActionResult Edit(Pasien pasien)
        {
            if (ModelState.IsValid)
            {
                _db.TablePasien.Update(pasien);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pasien);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Pasien pasien = _db.TablePasien.Find(id);
            _db.TablePasien.Remove(pasien);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Pasien pasien = _db.TablePasien.Find(id);
            return View(pasien);
        }
    }
}
