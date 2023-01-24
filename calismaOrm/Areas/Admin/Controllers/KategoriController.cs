using calismaOrm.Data.Repository.IRepository;
using calismaOrm.Models;
using Microsoft.AspNetCore.Mvc;

namespace calismaOrm.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class KategoriController : Controller
    {
        private readonly IUnitofWork _unitOfWork;
        public KategoriController(IUnitofWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Kategori> kategoriList = _unitOfWork.Kategori.GetAll();
            return View(kategoriList);
        }




        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Kategori.Add(kategori);
                _unitOfWork.Save();//******
                return RedirectToAction("Index");
            }

            return View(kategori);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }
            var kategori = _unitOfWork.Kategori.GetFirstOrDefault(x => x.Id == id);
            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
        }

        [HttpPost]
        public IActionResult Edit(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Kategori.Update(kategori);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(kategori);
        }
        public IActionResult Delete(int id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();

            }
            var kategori = _unitOfWork.Kategori.GetFirstOrDefault(x => x.Id == id);
            if (kategori == null)
            {
                return NotFound();
            }
            _unitOfWork.Kategori.Remove(kategori);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
