using AutoMapper;
using InventoryManagementApp.Application.DTOs.ModelDTOs;
using InventoryManagementApp.Application.DTOs.ShelfDTOs;
using InventoryManagementApp.Application.Services.GoodService;
using InventoryManagementApp.Application.Services.ModelService;
using InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ModelVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ShelfVMs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
	public class ModelController : Controller
	{
		private readonly IModelService _modelService;
		private readonly IMapper _mapper;

		public ModelController(IModelService modelService, IMapper mapper)
		{
			_modelService = modelService;
			_mapper = mapper;
		}
		public IActionResult Index()
		{
			return View();
		}

		//Listing Only Active Models
		public async Task<IActionResult> GetAllActiveModels()
		{
			var modelListDTO = await _modelService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
			var modelListVM = _mapper.Map<List<ModelListVM>>(modelListDTO);			
			return View(modelListVM);
		}

		//Listing All Models

		public async Task<IActionResult> GetAllModels()
		{
			List<ModelListVM> modelList = _mapper.Map<List<ModelListVM>>(await _modelService.All());
			return View(modelList);
		}

		//Adding Models
		[HttpGet]
		public IActionResult Create()
		{
			ModelCreateVM modelCreateVm = new ModelCreateVM();

			return View(modelCreateVm);

		}

		[HttpPost]
		public async Task<IActionResult> Create(ModelCreateVM modelCreateVm)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var modelCreateDto = _mapper.Map<ModelCreateDTO>(modelCreateVm);
					await _modelService.Create(modelCreateDto);
					return RedirectToAction("GetAllModels");
				}
				catch (Exception ex)
				{
					TempData["error"] = ex.Message;
				}
			}
			return View(modelCreateVm);
		}

		//Delete Model
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				await _modelService.Delete(id);
				return RedirectToAction("GetAllModels");
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
				return RedirectToAction("GetAllModels");
			}
		}

		//Update Model
		[HttpGet]
		public async Task<IActionResult> UpdateDetails(int id)
		{
			if (await _modelService.GetById(id) == null)
			{
				return NotFound();
			}
			else
			{
				ModelUpdateVM modelUpdateVm = _mapper.Map<ModelUpdateVM>(await _modelService.GetById(id));	
				return View(modelUpdateVm);
			}
		}

		[HttpPost]
		public async Task<IActionResult> UpdateDetails(ModelUpdateVM modelUpdateVM)
		{

			var modelUpdateDto = _mapper.Map<ModelUpdateDTO>(modelUpdateVM);
			await _modelService.Update(modelUpdateDto);
			return RedirectToAction("GetAllActiveModels");
		}
	}
}
