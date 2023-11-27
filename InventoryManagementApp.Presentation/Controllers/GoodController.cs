using AutoMapper;
using InventoryManagementApp.Application.DTOs.BrandDTOs;
using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Application.DTOs.SubCategoryDTOs;
using InventoryManagementApp.Application.Services.BrandService;
using InventoryManagementApp.Application.Services.CategoryService;
using InventoryManagementApp.Application.Services.GoodService;
using InventoryManagementApp.Application.Services.SubCategoryService;
using InventoryManagementApp.Presentation.Models.ViewModels.BrandVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.CategoryVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.SubCategoryVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;
        IWebHostEnvironment _webHostEnvironment;

        public GoodController(IGoodService goodService, IMapper mapper, IWebHostEnvironment webHostEnvironment, ICategoryService categoryService, ISubCategoryService subCategoryService, IBrandService brandService)
        {
            _goodService = goodService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
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
        public async Task<IActionResult> CreateCategory(string categoryName)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoryCreateDto = new CategoryCreateDTO() { CategoryName = categoryName };
                    var categoryId = await _categoryService.Create(categoryCreateDto);
                    return Json(new { value = categoryId, text = categoryName });
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            return BadRequest("Invalid Data");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(string brandName)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var brandCreateDto = new BrandCreateDTO() { BrandName = brandName };
                    var brandId = await _brandService.Create(brandCreateDto);
                    return Json(new { Value = brandId, Text = brandName });
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            return BadRequest("Invalid Data");
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(string subCategoryName,int categoryId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var subCategoryCreateDto = new SubCategoryCreateDTO() { SubCategoryName = subCategoryName, CategoryID = categoryId };
                    var subcategoryId = await _subCategoryService.CreateModal(subCategoryCreateDto);
                    return Json(new { value = subcategoryId, text = subCategoryName, catid=categoryId });
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                } 
            }
            return BadRequest("Invalid Data");
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
            goodCreateVm.CategoryList = await GetCategory();
            goodCreateVm.SubCategoryList = await GetSubCategory();
            goodCreateVm.BrandList = await GetBrand();

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
                TempData["error"] = ModelState.Values.First(x => x.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).Errors[0].ErrorMessage;
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
        public async Task<IActionResult> Update(int id)
        {
            if (await _goodService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                GoodUpdateVM goodUpdateVm = _mapper.Map<GoodUpdateVM>(await _goodService.GetById(id));
                goodUpdateVm.CategoryList = await GetCategory();
                goodUpdateVm.SubCategoryList = await GetSubCategory();
                goodUpdateVm.BrandList = await GetBrand();
                return View(goodUpdateVm);
            }
        }

        [Route("[controller]/Edit/{id}")]
        [HttpPost]
        public async Task<IActionResult> Update(GoodUpdateVM vm)
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


                if (goodVM.SubCategoryID != null)
                {
                    ViewBag.subCategoryName = (await _subCategoryService.GetById(goodVM.SubCategoryID.Value)).SubCategoryName;
                }

                if (goodVM.BrandID != null)
                {
                    ViewBag.brandName = (await _brandService.GetById(goodVM.BrandID.Value)).BrandName;

                }
                return View(goodVM);
            }
        }

        private async Task<SelectList> GetCategory()
        {
            var getCategorys = await _categoryService.All();

            return new SelectList(getCategorys.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CategoryName
            }), "Value", "Text");
        }

        private async Task<SelectList> GetSubCategory()
        {
            var getSubCategorys = await _subCategoryService.All();

            return new SelectList(getSubCategorys.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.SubCategoryName
            }), "Value", "Text");
        }

        private async Task<SelectList> GetBrand()
        {
            var getBrands = await _brandService.All();

            return new SelectList(getBrands.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.BrandName
            }), "Value", "Text");
        }
    }
}
