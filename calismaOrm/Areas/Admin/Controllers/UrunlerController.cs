using calismaOrm.Data.Repository.IRepository;
using calismaOrm.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace calismaOrm.Areas.Admin.Controllers
{


    [Area("Admin")]
    public class UrunlerController : Controller
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public UrunlerController(IUnitofWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;

        }
        public IActionResult Index()
        {
            var urunList = _unitOfWork.Urunler.GetAll();
            return View(urunList);
        }
        public IActionResult Crup(int? id=0)
        {
            UrunlerVM urunlerVM = new()
            {
                Urunler = new(),
                KategoriList = _unitOfWork.Kategori.GetAll().Select(l => new SelectListItem
                {
                    Text = l.KategoriAdi,
                    Value = l.Id.ToString()
                })
            };

            if (id == null || id <= 0)
            {
                return View(urunlerVM);
            }

            urunlerVM.Urunler = _unitOfWork.Urunler.GetFirstOrDefault(x => x.Id == id);

            if (urunlerVM.Urunler == null)
            {
                return View(urunlerVM);
            }

            return View(urunlerVM);
           
        }

        [HttpPost]
        public IActionResult Crup(UrunlerVM urunlerVM, IFormFile file)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;

            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploadRoot = Path.Combine(wwwRootPath, @"img\urunlers");
                var extension = Path.GetExtension(file.FileName);

                if (urunlerVM.Urunler.Resim != null)
                {
                    var oldPicPath = Path.Combine(wwwRootPath, urunlerVM.Urunler.Resim);
                    if (System.IO.File.Exists(oldPicPath))
                    {
                        System.IO.File.Delete(oldPicPath);
                    }
                }

                using (var fileStream = new FileStream(Path.Combine(uploadRoot, fileName + extension),
                     FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                urunlerVM.Urunler.Resim = @"\img\urunlers\" + fileName + extension;

            }
            if (urunlerVM.Urunler.Id <= 0)
            {
                _unitOfWork.Urunler.Add(urunlerVM.Urunler);
            }
            else
            {
                _unitOfWork.Urunler.Update(urunlerVM.Urunler);
            }
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }














        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var product = _unitOfWork.Urunler.GetFirstOrDefault(x => x.Id == id);
            _unitOfWork.Urunler.Remove(product);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }





    }
}
