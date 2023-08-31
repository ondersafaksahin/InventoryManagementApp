using AutoMapper;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDTOs;
using InventoryManagementApp.Application.Services.BillOfMaterialsService;
using InventoryManagementApp.Presentation.Models.ViewModels.BillOfMaterialsVMs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
	public class BillOfMaterialsController : Controller
	{
		IBillOfMatieralsService _billOfMatieralsService;
		IMapper _mapper;

        public BillOfMaterialsController(IBillOfMatieralsService billOfMatieralsService, IMapper mapper)
        {
			_billOfMatieralsService = billOfMatieralsService;
			_mapper = mapper;
        }

        public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetAllActiveBOMs() 
		{
			var bomList = _mapper.Map<List<BillOfMaterialsListVM>>(await _billOfMatieralsService.GetDefaults(x => x.Status == Domain.Enums.Status.Active));
			return View(bomList); 
		}

		public async Task<IActionResult> GetAllBOMs()
		{
			var bomList = _mapper.Map<List<BillOfMaterialsListVM>>(await _billOfMatieralsService.All());
			return View(bomList);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(BillOfMaterialsCreateVM bomCreateVM)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var bomInfo = _mapper.Map<BOMCreateDTO>(bomCreateVM);
					await _billOfMatieralsService.Create(bomInfo);
					return RedirectToAction("GetAllActiveBOMs");
				}
				catch (Exception ex)
				{
					TempData["Error"] = ex.Message;
				}
			}
			return View(bomCreateVM);
		}

		[HttpPost]
		public async Task<IActionResult> Delete(int bomId)
		{
			try
			{
				await _billOfMatieralsService.Delete(bomId);
			}
			catch (Exception ex)
			{
				TempData["Error"] = ex.Message;
			}
			return RedirectToAction("GetAllActiveBOMs");
		}

		[HttpGet]
		public async Task<IActionResult> Update(int bomId)
		{
			var bomVM = _mapper.Map<BillOfMaterialsUpdateVM>(await _billOfMatieralsService.GetById(bomId));
			return View(bomVM);
		}


		[HttpPost]
		public async Task<IActionResult> Update(BillOfMaterialsUpdateVM bomUpdateVM)
		{
			var bomdto = _mapper.Map<BOMUpdateDTO>(bomUpdateVM);
			if (ModelState.IsValid)
			{
				try
				{
					await _billOfMatieralsService.Update(bomdto);
					return RedirectToAction("GetAllActiveBOMs");
				}
				catch (Exception ex)
				{
					TempData["Error"] = ex.Message;
				}
			}
			return View(bomUpdateVM);
		}
	}
}
