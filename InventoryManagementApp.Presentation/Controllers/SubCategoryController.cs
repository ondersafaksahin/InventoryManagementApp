using AutoMapper;
using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Application.DTOs.SubCategoryDTOs;
using InventoryManagementApp.Application.Services.CategoryService;
using InventoryManagementApp.Application.Services.SubCategoryService;
using InventoryManagementApp.Presentation.Models.ViewModels.CategoryVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.SubCategoryVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

namespace InventoryManagementApp.Presentation.Controllers
{
	public class SubCategoryController : Controller
	{
		private readonly IMapper _mapper;
		private readonly ISubCategoryService _subCategoryService;
		private readonly ICategoryService _categoryService;
        public SubCategoryController(IMapper mapper, ISubCategoryService subCategoryService, ICategoryService categoryService)
        {
            _mapper = mapper;
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
        }
        public IActionResult Index()
		{
			return View();
		}

        //Listing Only Active SubCategories
        [Route("[controller]/ListActive")]
        public async Task<IActionResult> GetAllActiveSubCategories()
		{
			var subCategoryListDTO = await _subCategoryService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
			var subCategoryListVM = _mapper.Map<List<SubCategoryListVM>>(subCategoryListDTO);
			return View(subCategoryListVM);

		}

        //Listing All SubCategories
        [Route("[controller]/List")]
        public async Task<IActionResult> GetAllSubCategories()
		{
			List<SubCategoryListVM> subCategoryListVMs = _mapper.Map<List<SubCategoryListVM>>(await _subCategoryService.All());
			return View(subCategoryListVMs);
		}

		//Adding SubCategory
		[HttpGet]
		public async Task<IActionResult> Create()
		{
			SubCategoryCreateVM subCategoryCreateVM = new SubCategoryCreateVM()
			{
				CategoryList = await GetCategory()
			};
            return View(subCategoryCreateVM);
		}

		[HttpPost]
		public async Task<IActionResult> Create(SubCategoryCreateVM subCategoryCreateVm)
		{
            if (!ModelState.IsValid)
            {
                subCategoryCreateVm.CategoryList = await GetCategory();
                return View(subCategoryCreateVm);
            }
            if (ModelState.IsValid)
			{
				try
				{
					var subCategoryCreateDto = _mapper.Map<SubCategoryCreateDTO>(subCategoryCreateVm);
					await _subCategoryService.Create(subCategoryCreateDto);
					return RedirectToAction("GetAllActiveSubCategories");
				}
				catch (Exception ex)
				{
					TempData["error"] = ex.Message;
				}
			}
			return View(subCategoryCreateVm);
		}

		//Delete SubCategory
		public async Task<IActionResult> Delete(int id, bool active)
		{
			try
			{
				await _subCategoryService.Delete(id);
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
			}
            if (active)
            {
                return RedirectToAction("GetAllActiveSubCategories");
            }
            return RedirectToAction("GetAllSubCategories");

        }

        [Route("[controller]/Edit/{id}")]
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
                subCategoryUpdateVm.CategoryList = await GetCategory();
                return View(subCategoryUpdateVm);
			}
		}

        [Route("[controller]/Edit/{id}")]
        [HttpPost]
		public async Task<IActionResult> UpdateDetails(SubCategoryUpdateVM subCategoryUpdateVm)
		{

			var subCategoryUpdateDto = _mapper.Map<SubCategoryUpdateDTO>(subCategoryUpdateVm);
			await _subCategoryService.Update(subCategoryUpdateDto);
			return RedirectToAction("GetAllActiveSubCategories");
		}

        public async Task<SelectList> GetCategory()
        {
			var getCategorys = await _categoryService.All();

            return new SelectList(getCategorys.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.CategoryName
            }), "Value", "Text");
        }

    }
}
