using AutoMapper;
using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Application.DTOs.ShelfDTOs;
using InventoryManagementApp.Application.Services.BrandService;
using InventoryManagementApp.Application.Services.CategoryService;
using InventoryManagementApp.Presentation.Models.ViewModels.CategoryVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ShelfVMs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IMapper _mapper;
		private readonly ICategoryService _categoryService;
		public CategoryController(IMapper mapper, ICategoryService categoryService)
		{
			_mapper = mapper;
			_categoryService = categoryService;
		}
		public IActionResult Index()
		{
			return View();
		}

		//Listing Only Active Categories
		public async Task<IActionResult> GetAllActiveCategories()
		{
			var categoryListDTO = await _categoryService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
			var categoryListVM = _mapper.Map<List<CategoryListVM>>(categoryListDTO);

			return View(categoryListVM);
		}

		//Listing All Categories

		public async Task<IActionResult> GetAllCategories()
		{
			List<CategoryListVM> categoryList = _mapper.Map<List<CategoryListVM>>(await _categoryService.All());
			return View(categoryList);
		}

        
        //Adding Category
        [HttpGet]
		public IActionResult Create()
		{
			CategoryCreateVM categoryCreateVm = new CategoryCreateVM();

			return View(categoryCreateVm);

		}


		[HttpPost]
		public async Task<IActionResult> Create(CategoryCreateVM categoryCreateVm)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var categoryCreateDto = _mapper.Map<CategoryCreateDTO>(categoryCreateVm);
					await _categoryService.Create(categoryCreateDto);
					return RedirectToAction("GetAllCategories");
				}
				catch (Exception ex)
				{
					TempData["error"] = ex.Message;
				}
			}
			return View(categoryCreateVm);
		}

		//Delete Category
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _categoryService.Delete(id);
				return RedirectToAction("GetAllCategories");
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("GetAllCategories");
			}
		}

		[HttpGet]
		public async Task<IActionResult> UpdateDetails(int id)
		{
			if (await _categoryService.GetById(id) == null)
			{
				return NotFound();
			}
			else
			{
				CategoryUpdateVM categoryUpdateVm = _mapper.Map<CategoryUpdateVM>(await _categoryService.GetById(id));
				return View(categoryUpdateVm);
			}
		}

		[HttpPost]
		public async Task<IActionResult> UpdateDetails(CategoryUpdateVM categoryUpdateVm)
		{

			var categoryUpdateDto = _mapper.Map<CategoryUpdateDTO>(categoryUpdateVm);
			await _categoryService.Update(categoryUpdateDto);
			return RedirectToAction("GetAllActiveCategories");
		}

	}
}
