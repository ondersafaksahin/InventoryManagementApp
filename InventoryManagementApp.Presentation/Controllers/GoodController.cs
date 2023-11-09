using AutoMapper;
using InventoryManagementApp.Application.DTOs.BrandDTOs;
using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Application.DTOs.ModelDTOs;
using InventoryManagementApp.Application.DTOs.SubCategoryDTOs;
using InventoryManagementApp.Application.Services.BrandService;
using InventoryManagementApp.Application.Services.CategoryService;
using InventoryManagementApp.Application.Services.GoodService;
using InventoryManagementApp.Application.Services.ModelService;
using InventoryManagementApp.Application.Services.SubCategoryService;
using InventoryManagementApp.Presentation.Models.ViewModels.BrandVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.CategoryVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ConversionVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ModelVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.SubCategoryVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.SupplierVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;

namespace InventoryManagementApp.Presentation.Controllers
{
    //[Authorize(Roles = "Admin", "Manager", "Employee")]

    public class GoodController : Controller
    {

        private readonly IGoodService _goodService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IModelService _modelService;
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;
        IWebHostEnvironment _webHostEnvironment;

        public GoodController(IGoodService goodService, IMapper mapper, IWebHostEnvironment webHostEnvironment, ICategoryService categoryService, ISubCategoryService subCategoryService, IModelService modelService, IBrandService brandService)
        {
            _goodService = goodService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _modelService = modelService;
            _brandService = brandService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetSubcategories(int categoryId)
        {
            var subcategories = await _subCategoryService.GetDefaults(x => x.CategoryID == categoryId);
            var subcategoryItems = subcategories.Select(subcategory => new SubCategoryListVM
            {
                ID = subcategory.ID,
                SubCategoryName = subcategory.SubCategoryName
            }).ToList();
            return Json(subcategoryItems);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateVM categoryCreateVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoryCreateDto = _mapper.Map<CategoryCreateDTO>(categoryCreateVm);
                    await _categoryService.Create(categoryCreateDto);
                    return RedirectToAction("Create");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateModel(ModelCreateVM modelCreateVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var modelCreateDto = _mapper.Map<ModelCreateDTO>(modelCreateVm);
                    await _modelService.Create(modelCreateDto);
                    return RedirectToAction("Create");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(BrandCreateVM brandCreateVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var brandCreateDto = _mapper.Map<BrandCreateDTO>(brandCreateVm);
                    await _brandService.Create(brandCreateDto);
                    return RedirectToAction("Create");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(SubCategoryCreateVM subCategoryCreateVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var subCategoryCreateDto = _mapper.Map<SubCategoryCreateDTO>(subCategoryCreateVm);
                    await _subCategoryService.Create(subCategoryCreateDto);
                    return RedirectToAction("Create");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            return View();
        }


        //Listing only active goods
        [Route("[controller]/ListActive")]
        public async Task<IActionResult> GetAllActiveGoods()
        {
            var goodListDTO = await _goodService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var goodListVM = _mapper.Map<List<GoodListVM>>(goodListDTO);

            return View(goodListVM);
        }


        //Listing all goods
        [Route("[controller]/List")]
        public async Task<IActionResult> GetAllGoods()
        {
            List<GoodListVM> goodList = _mapper.Map<List<GoodListVM>>(await _goodService.All());
            return View(goodList);
        }

        //Adding Good
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            GoodCreateVM goodCreateVm = new GoodCreateVM();
            goodCreateVm.CategoryList = await _categoryService.All();
            goodCreateVm.SubCategoryList = await _subCategoryService.All();
            goodCreateVm.ModelList = await _modelService.All();
            goodCreateVm.BrandList = await _brandService.All();

            return View(goodCreateVm);

        }


        [HttpPost]
        public async Task<IActionResult> Create(GoodCreateVM goodCreateVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var goodCreateDto = _mapper.Map<GoodCreateDTO>(goodCreateVm);
                    await _goodService.Create(goodCreateDto);
                    return RedirectToAction("GetAllGoods");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            else
            {
                TempData["error"] = ModelState.Values.First().Errors[0].ErrorMessage;
            }
            return View(goodCreateVm);
        }

        //Delete
        public async Task<IActionResult> Delete(int id, bool active)
        {
            try
            {
                await _goodService.Delete(id);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            if (active)
            {
                return RedirectToAction("GetAllActiveGoods");
            }
            return RedirectToAction("GetAllGoods");
        }


        [Route("[controller]/Edit/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateDetails(int id)
        {
            if (await _goodService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                GoodUpdateVM goodUpdateVm = _mapper.Map<GoodUpdateVM>(await _goodService.GetById(id));

                return View(goodUpdateVm);
            }
        }
        [Route("[controller]/Edit/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateDetails(GoodUpdateVM vm)
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

            var goodUpdateDto = _mapper.Map<GoodUpdateDTO>(vm);
            await _goodService.Update(goodUpdateDto);

            return RedirectToAction("GetAllActiveGoods");
        }


        public async Task<IActionResult> Details(int id)
        {
            if (await _goodService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                GoodVM goodVM = _mapper.Map<GoodVM>(await _goodService.GetById(id));
                ViewBag.categoryName = (await _categoryService.GetById(goodVM.CategoryID.Value)).CategoryName;


                if(goodVM.SubCategoryID != null)
                {
                    ViewBag.subCategoryName = (await _subCategoryService.GetById(goodVM.SubCategoryID.Value)).SubCategoryName;
                }
                
                if(goodVM.ModelID != null)
                {
                    ViewBag.modelName = (await _modelService.GetById(goodVM.ModelID.Value)).ModelName;
                }

                if (goodVM.BrandID != null)
                {
                    ViewBag.brandName = (await _brandService.GetById(goodVM.BrandID.Value)).BrandName;
                   
                }
                 return View(goodVM);
            }
        }

    }
}
