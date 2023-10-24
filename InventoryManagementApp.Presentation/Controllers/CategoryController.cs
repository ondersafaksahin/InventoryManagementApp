using AutoMapper;
using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Application.DTOs.SubCategoryDTOs;
using InventoryManagementApp.Application.Services.CategoryService;
using InventoryManagementApp.Application.Services.SubCategoryService;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using InventoryManagementApp.Presentation.Models.ViewModels.CategoryVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.SubCategoryVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.WarehouseVMs;
using Microsoft.AspNetCore.Mvc;


namespace InventoryManagementApp.Presentation.Controllers
{
	public class CategoryController : Controller
	{
		private readonly IMapper _mapper;
		private readonly ICategoryService _categoryService;
		private readonly ISubCategoryService _subCategoryService;
        public CategoryController(IMapper mapper, ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }
        public IActionResult Index()
		{
			return View();
		}

        //Listing Only Active Categories
        [Route("[controller]/ListActive")]
        public async Task<IActionResult> GetAllActiveCategories()
		{
			var categoryListDTO = await _categoryService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
			var categoryListVM = _mapper.Map<List<CategoryListVM>>(categoryListDTO);

			return View(categoryListVM);
		}

        //Listing All Categories
        [Route("[controller]/List")]
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
					return RedirectToAction("GetAllActiveCategories");
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
				return RedirectToAction("GetAllActiveCategories");
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("GetAllActiveCategories");
			}
		}

        [Route("[controller]/Edit/{id}")]
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

                categoryUpdateVm.SubCategories = _mapper.Map<List<SubCategoryListVM>>(await _subCategoryService.GetDefaults(x => x.CategoryID == categoryUpdateVm.ID && x.Status == Status.Active));

                return View(categoryUpdateVm);
			}
		}

        [Route("[controller]/Edit/{id}")]
        [HttpPost]
		public async Task<IActionResult> UpdateDetails(CategoryUpdateVM categoryUpdateVm)
		{

			var categoryUpdateDto = _mapper.Map<CategoryUpdateDTO>(categoryUpdateVm);
			await _categoryService.Update(categoryUpdateDto);
			return RedirectToAction("GetAllActiveCategories");
		}

        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(CategoryUpdateVM categoryUpdateVM)
        {
                try
                {
                    var subCategoryCreateDto = _mapper.Map<SubCategoryCreateDTO>(categoryUpdateVM.newSubCategory);
                    await _subCategoryService.Create(subCategoryCreateDto);
                    CategoryUpdateVM category = _mapper.Map<CategoryUpdateVM>(await _categoryService.GetById(categoryUpdateVM.newSubCategory.CategoryID));
                    return RedirectToAction("UpdateDetails", category);
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            
            return View(categoryUpdateVM);
        }


        //UpdateSubCategory
        [HttpGet]
        public async Task<IActionResult> UpdateSubCategory(int id)
        {
            if (await _subCategoryService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                SubCategoryUpdateVM subCategoryUpdateVM = _mapper.Map<SubCategoryUpdateVM>(await _subCategoryService.GetById(id));
                CategoryUpdateVM category = _mapper.Map<CategoryUpdateVM>(await _categoryService.GetById(subCategoryUpdateVM.CategoryID));
                category.updateSubCategory = subCategoryUpdateVM;
                return PartialView("SubCategoryUpdate", category);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubCategory(CategoryUpdateVM vm)
        {

            var sbUpdateDto = _mapper.Map<SubCategoryUpdateDTO>(vm.updateSubCategory);
            await _subCategoryService.Update(sbUpdateDto);
            CategoryUpdateVM category = _mapper.Map<CategoryUpdateVM>(await _categoryService.GetById(sbUpdateDto.CategoryID));
            return RedirectToAction("UpdateDetails", category);
        }

        //DeleteSubCategory
        public async Task<IActionResult> DeleteSubCategory(int id, int categoryid)
        {
            try
            {
                await _subCategoryService.Delete(id);
                CategoryUpdateVM category = _mapper.Map<CategoryUpdateVM>(await _categoryService.GetById(categoryid));
                return RedirectToAction("UpdateDetails", category);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                CategoryUpdateVM category = _mapper.Map<CategoryUpdateVM>(await _categoryService.GetById(categoryid));
                return RedirectToAction("UpdateDetails", category);
            }
        }

        //private async Task<SelectList> GetSubCategory()
        //{
        //    var getSubCategories = await _subCategoryService.All();

        //    return new SelectList(getSubCategories.Select(x => new SelectListItem
        //    {
        //        Value = x.ID.ToString(),
        //        Text = x.SubCategoryName,
        //        Group= x.Description

        //    }), "Value", "Text");
        //}

    }
}
