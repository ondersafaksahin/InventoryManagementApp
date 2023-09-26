﻿using AutoMapper;
using InventoryManagementApp.Application.DTOs.BrandDTOs;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Application.DTOs.ShelfDTOs;
using InventoryManagementApp.Application.Services.BrandService;
using InventoryManagementApp.Presentation.Models.ViewModels.BrandVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ShelfVMs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
    public class BrandController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBrandService _brandService;       
        public BrandController(IMapper mapper, IBrandService brandService)
        {
            _mapper = mapper;
            _brandService = brandService;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Listing all brands
        [Route("[controller]/List")]
        public async Task<IActionResult> GetAllBrands()
        {
            List<BrandListVM> brandList = _mapper.Map<List<BrandListVM>>(await _brandService.All());
            return View(brandList);
        }

        [Route("[controller]/ListActive")]
        public async Task<IActionResult> GetAllActiveBrands()
        {
            List<BrandListVM> brandList = _mapper.Map<List<BrandListVM>>(await _brandService.GetDefaults(x=>x.Status==Domain.Enums.Status.Active));
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
				try
				{
					var brandCreateDto = _mapper.Map<BrandCreateDTO>(brandCreateVM);
                    if (User.Identity.IsAuthenticated)
                    {
                        brandCreateDto.CreatedBy = User.Identity.Name;
                    }
                    await _brandService.Create(brandCreateDto);
					return RedirectToAction("GetAllActiveBrands");
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
			return View(brandCreateVM);
		}

        //Delete Brand
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _brandService.Delete(id);
                return RedirectToAction("GetAllActiveBrands");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("GetAllActiveBrands");
            }
        }

        //Update Brand
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
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
        public async Task<IActionResult> Edit(BrandUpdateVM brandUpdateVM)
        {
            var brandUpdateDto = _mapper.Map<BrandUpdateDTO>(brandUpdateVM);
            await _brandService.Update(brandUpdateDto);
            return RedirectToAction("GetAllActiveBrands");
        }
    }
}
