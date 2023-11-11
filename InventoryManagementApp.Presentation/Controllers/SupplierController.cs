using AutoMapper;
using InventoryManagementApp.Application.DTOs.SupplierDTOs;
using InventoryManagementApp.Application.Services.SupplierService;
using InventoryManagementApp.Presentation.Models.ViewModels.BrandVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.SupplierVMs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
	public class SupplierController : Controller
	{
		private readonly ISupplierService _supplierService;
		private readonly IMapper _mapper;
		public SupplierController(ISupplierService supplierService, IMapper mapper)
		{
			_supplierService = supplierService;
			_mapper = mapper;
		}
		public IActionResult Index()
		{
			return View();
		}

		//Listing Only Active Suppliers
		[Route("[controller]/ListActive")]
		public async Task<IActionResult> GetAllActiveSuppliers()
		{
			var supplierListDTO = await _supplierService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
			var supplierListVM = _mapper.Map<List<SupplierListVM>>(supplierListDTO);
			return View(supplierListVM);
		}

        //Listing All Suppliers
        [Route("[controller]/List")]
        public async Task<IActionResult> GetAllSuppliers()
		{
			List<SupplierListVM> supplierList = _mapper.Map<List<SupplierListVM>>(await _supplierService.All());
			return View(supplierList);
		}

		//Adding Supplier
		[HttpGet]
		public IActionResult Create()
		{
			SupplierCreateVM supplierCreateVm = new SupplierCreateVM();

			return View(supplierCreateVm);

		}

		[HttpPost]
		public async Task<IActionResult> Create(SupplierCreateVM supplierCreateVM)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var supplierCreateDto = _mapper.Map<SupplierCreateDTO>(supplierCreateVM);
					await _supplierService.Create(supplierCreateDto);
					return RedirectToAction("GetAllSuppliers");
				}
				catch (Exception ex)
				{
					TempData["error"] = ex.Message;
				}
			}
			return View(supplierCreateVM);
		}

		//Delete Supplier
		public async Task<IActionResult> Delete(int id,bool active)
		{
			try
			{
				await _supplierService.Delete(id);
				if (active)
				{
                    return RedirectToAction("GetAllActiveSuppliers");
                }
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
                if (active)
                {
                    return RedirectToAction("GetAllActiveSuppliers");
                }  
			}
            return RedirectToAction("GetAllSuppliers");
        }

		//Update Supplier
		[HttpGet]
		public async Task<IActionResult> UpdateDetails(int id)
		{
			if (await _supplierService.GetById(id) == null)
			{
				return NotFound();
			}
			else
			{
				SupplierUpdateVM supplierUpdateVm = _mapper.Map<SupplierUpdateVM>(await _supplierService.GetById(id));
				return View(supplierUpdateVm);
			}
		}

		[HttpPost]
		public async Task<IActionResult> UpdateDetails(SupplierUpdateVM supplierUpdateVm)
		{
			var supplierUpdateDto = _mapper.Map<SupplierUpdateDTO>(supplierUpdateVm);
			await _supplierService.Update(supplierUpdateDto);
			return RedirectToAction("GetAllSuppliers");
		}

        public async Task<IActionResult> Details(int id)
        {
            if (await _supplierService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                SupplierVM supplierVM = _mapper.Map<SupplierVM>(await _supplierService.GetById(id));

                return View(supplierVM);
            }
        }
    }
}
