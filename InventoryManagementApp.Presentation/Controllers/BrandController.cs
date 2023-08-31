using AutoMapper;
using InventoryManagementApp.Application.DTOs.BrandDTOs;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Application.Services.BrandService;
using InventoryManagementApp.Presentation.Models.ViewModels.BrandVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
    public class BrandController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBrandService _brandService;
        IWebHostEnvironment _webHostEnvironment;
        public BrandController(IMapper mapper, IBrandService brandService, IWebHostEnvironment webHostEnvironment)
        {
            _mapper = mapper;
            _brandService = brandService;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Listing only active brands
        public async Task<IActionResult> GetAllActiveBrands()
        {
            var brandListDto = await _brandService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var brandListVM = _mapper.Map<List<BrandListVM>>(brandListDto);
            return View(brandListVM);
        }

        //Listing all brands
        public async Task<IActionResult> GetAllBrands()
        {
            List<BrandListVM> brandList = _mapper.Map<List<BrandListVM>>(await _brandService.All());
            return View(brandList);
        }

        //Adding Brand
        [HttpGet]
        public IActionResult Create()
        {
            BrandCreateVM brandCreateVM = new BrandCreateVM();
            return View(brandCreateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandCreateVM brandCreateVM)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {


                    string wwwrootDosyaYolu = _webHostEnvironment.WebRootPath;
                    string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName);
                    string dosyaUzantisi = Path.GetExtension(Request.Form.Files[0].FileName);
                    string tamDosyaAdi = $"{dosyaAdi}_{Guid.NewGuid()}{dosyaUzantisi}";
                    string yeniDosyaYolu = Path.Combine($"{wwwrootDosyaYolu}/images/{tamDosyaAdi}");

                    using (var fileStream = new FileStream(yeniDosyaYolu, FileMode.Create))
                    {
                        Request.Form.Files[0].CopyTo(fileStream);

                    }

                    //vm.picture = tamDosyaAdi;
                }

                else
                {
                    //vm.picture = vm.picture;
                }
                try
                {
                    var brandCreateDto = _mapper.Map<BrandCreateDTO>(brandCreateVM);
                    await _brandService.Create(brandCreateDto);
                    return RedirectToAction("GetAllBrands");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            return View(brandCreateVM);
        }

        //Delete Brand
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _brandService.Delete(id);
                return RedirectToAction("GetAllBrands");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("GetAllBrands");
            }
        }

        //Update Brand
        [HttpGet]
        public async Task<IActionResult> UpdateDetails(int id)
        {
            if (await _brandService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                BrandUpdateVM brandUpdateVM = _mapper.Map<BrandUpdateVM>(await _brandService.GetById(id));

                return View(brandUpdateVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetails(BrandUpdateVM brandUpdateVM)
        {

            if (Request.Form.Files.Count > 0)
            {

                string wwwrootDosyaYolu = _webHostEnvironment.WebRootPath;
                string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName);
                string dosyaUzantisi = Path.GetExtension(Request.Form.Files[0].FileName);
                string tamDosyaAdi = $"{dosyaAdi}_{Guid.NewGuid()}{dosyaUzantisi}";
                string yeniDosyaYolu = Path.Combine($"{wwwrootDosyaYolu}/images/{tamDosyaAdi}");

                using (var fileStream = new FileStream(yeniDosyaYolu, FileMode.Create))
                {
                    Request.Form.Files[0].CopyTo(fileStream);

                }

                //vm.picture = tamDosyaAdi;
            }

            else
            {
                //vm.picture = vm.picture;
            }

            var brandUpdateDto = _mapper.Map<BrandUpdateDTO>(brandUpdateVM);
            await _brandService.Update(brandUpdateDto);
            return RedirectToAction("GetAllActiveBrands");
        }
    }
}
