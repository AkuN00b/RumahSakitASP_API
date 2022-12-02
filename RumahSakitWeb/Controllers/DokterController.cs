using Microsoft.AspNetCore.Mvc;
using RumahSakitWeb.Data;
using RumahSakitWeb.Models;

namespace RumahSakitWeb.Controllers
{
    public class DokterController : Controller
    {
        private readonly ApplicationDbContext _db;
        private string _baseAddress = "https://localhost:44357/api/Dokter/";


		public DokterController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Dokter> dataDokter;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseAddress);
                HttpResponseMessage response = await client.GetAsync("GetAllDataDokter");

                if (response.IsSuccessStatusCode)
                {
                    dataDokter = await response.Content.ReadAsAsync<IEnumerable<Dokter>>();
					return View(dataDokter);
				}

				return NotFound();
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Dokter obj)
        {
            obj.Alamat ??= "";

            if (obj.Alamat.ToUpper().Equals("BEKASI") || obj.Alamat.ToUpper().Equals("BANDUNG") || obj.Alamat.ToUpper().Equals("JAKARTA")) {
                ModelState.AddModelError("Alamat", "Alamat tidak boleh di " + obj.Alamat + " !!");
            }

            if (ModelState.IsValid)
            {
				using (var client = new HttpClient())
				{
					client.BaseAddress = new Uri(_baseAddress);
					HttpResponseMessage response = await client.PostAsJsonAsync("CreateDataDokter", obj);

					if (response.IsSuccessStatusCode)
					{
                        TempData["notifikasi"] = "Tambah Data Berhasil";
						return RedirectToAction("Index");
					}

					return BadRequest();
				}
			}
                
            return View(obj);
        }

        public IActionResult Edit(int id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            } else
            {
                Dokter? objDokter;

                try
                {
                    objDokter = _db.TableDokter.Find(id);
                } catch {
                    objDokter = null;
                }

                //Dokter dokter = _db.TableDokter.Find(id);

                if (objDokter == null)
                {
                    return NotFound();
                }

                return View(objDokter);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Dokter dokter)
        {
            if (ModelState.IsValid)
            {
                _db.TableDokter.Update(dokter);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(dokter);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Dokter dokter = _db.TableDokter.Find(id);
            _db.TableDokter.Remove(dokter);
            _db.SaveChanges();

            //set route to DokterController
            return RedirectToAction(nameof(Index));
        }
    }
}
