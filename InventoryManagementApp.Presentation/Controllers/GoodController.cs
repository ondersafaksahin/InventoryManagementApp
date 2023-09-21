﻿using AutoMapper;
using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Application.Services.BrandService;
using InventoryManagementApp.Application.Services.CategoryService;
using InventoryManagementApp.Application.Services.GoodService;
using InventoryManagementApp.Application.Services.ModelService;
using InventoryManagementApp.Application.Services.SubCategoryService;
using InventoryManagementApp.Presentation.Models.ViewModels.CategoryVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateVM categoryCreateVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoryCreateDto = _mapper.Map<CategoryCreateDTO>(categoryCreateVm);
                    categoryCreateDto.Name = categoryCreateVm.CategoryName;
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


        //Listing only active goods
        public async Task<IActionResult> GetAllActiveGoods()
        {
            var goodListDTO = await _goodService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var goodListVM = _mapper.Map<List<GoodListVM>>(goodListDTO);

            return View(goodListVM);
        }


        //Listing all goods

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
              
                  var goodCreateDto = _mapper.Map<GoodCreateDTO>(goodCreateVm);
                    await _goodService.Create(goodCreateDto);
                    return RedirectToAction("GetAllGoods");
                
                //catch (Exception ex)
                //{
                //    TempData["error"] = ex.Message;
                //}
            }
            return View(goodCreateVm);
        }

        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _goodService.Delete(id);
                return RedirectToAction("GetAllGoods");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("GetAllGoods");
            }
        }



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

    }
}
