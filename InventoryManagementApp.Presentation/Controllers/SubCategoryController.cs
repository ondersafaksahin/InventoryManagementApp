using AutoMapper;
using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Application.DTOs.SubCategoryDTOs;
using InventoryManagementApp.Application.Services.CategoryService;
using InventoryManagementApp.Application.Services.SubCategoryService;
using InventoryManagementApp.Presentation.Models.ViewModels.CategoryVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.SubCategoryVMs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
	public class SubCategoryController : Controller
	{
		private readonly IMapper _mapper;
		private readonly ISubCategoryService _subCategoryService;
		public SubCategoryController(IMapper mapper, ISubCategoryService subCategoryService)
		{
			_mapper = mapper;
			_subCategoryService = subCategoryService;
		}
		public IActionResult Index()
		{
			return View();
		}

		//Listing Only Active SubCategories
		public async Task<IActionResult> GetAllActiveSubCategories()
		{
			var subCategoryListDTO = await _subCategoryService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
			var subCategoryListVM = _mapper.Map<List<SubCategoryListVM>>(subCategoryListDTO);
			return View(subCategoryListVM);

		}

		//Listing All SubCategories

		public async Task<IActionResult> GetAllSubCategories()
		{
			List<SubCategoryListVM> subCategoryListVMs = _mapper.Map<List<SubCategoryListVM>>(await _subCategoryService.All());
			return View(subCategoryListVMs);
		}

		//Adding SubCategory
		[HttpGet]
		public IActionResult Create()
		{
			SubCategoryCreateVM subCategoryCreateVM = new SubCategoryCreateVM();
			return View(subCategoryCreateVM);
		}

		[HttpPost]
		public async Task<IActionResult> Create(SubCategoryCreateVM subCategoryCreateVm)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var subCategoryCreateDto = _mapper.Map<SubCategoryCreateDTO>(subCategoryCreateVm);
					await _subCategoryService.Create(subCategoryCreateDto);
					return RedirectToAction("GetAllSubCategories");
				}
				catch (Exception ex)
				{
					TempData["error"] = ex.Message;
				}
			}
			return View(subCategoryCreateVm);
		}

		//Delete SubCategory
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _subCategoryService.Delete(id);
				return RedirectToAction("GetAllSubCategories");
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("GetAllSubCategories");
			}
		}

		[HttpGet]
		public async Task<IActionResult> UpdateDetails(int id)
		{
			if (await _subCategoryService.GetById(id) == null)
			{
				return NotFound();
			}
			else
			{
				SubCategoryUpdateVM subCategoryUpdateVm = _mapper.Map<SubCategoryUpdateVM>(await _subCategoryService.GetById(id));
				return View(subCategoryUpdateVm);
			}
		}

		[HttpPost]
		public async Task<IActionResult> UpdateDetails(SubCategoryUpdateVM subCategoryUpdateVm)
		{

			var subCategoryUpdateDto = _mapper.Map<SubCategoryUpdateDTO>(subCategoryUpdateVm);
			await _subCategoryService.Update(subCategoryUpdateDto);
			return RedirectToAction("GetAllActiveSubCategories");
		}
	}
}
