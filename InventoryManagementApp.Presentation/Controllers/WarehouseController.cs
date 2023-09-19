using AutoMapper;
using InventoryManagementApp.Application.DTOs.ShelfDTOs;
using InventoryManagementApp.Application.DTOs.WareHouseDTOs;
using InventoryManagementApp.Application.Services.ShelfService;
using InventoryManagementApp.Application.Services.WareHouseService;
using InventoryManagementApp.Presentation.Models.ViewModels.ShelfVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.WarehouseVMs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
    //[Authorize(Roles = "Admin", "Manager", "Employee")]

    public class WarehouseController : Controller
    {
        private readonly IWareHouseService _warehouseService;
        private readonly IMapper _mapper;
        IWebHostEnvironment _webHostEnvironment;

        public WarehouseController(IWareHouseService warehouseService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _warehouseService = warehouseService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }

        //Listing only active warehouses
        public async Task<IActionResult> GetAllActiveWarehouses()
        {
            var warehouseListDTO = await _warehouseService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var warehouseListVM = _mapper.Map<List<WarehouseListVM>>(warehouseListDTO);

            return View(warehouseListVM);
        }


        //Listing all warehouses

        public async Task<IActionResult> GetAllWarehouses()
        {
            List<WarehouseListVM> warehouseList = _mapper.Map<List<WarehouseListVM>>(await _warehouseService.All());
            return View(warehouseList);
        }

        //Adding Warehouse
        [HttpGet]
        public IActionResult Create()
        {
            WarehouseCreateVM warehouseCreateVm = new WarehouseCreateVM();

            return View(warehouseCreateVm);

        }


        [HttpPost]
        public async Task<IActionResult> Create(WarehouseCreateVM warehouseCreateVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var warehouseCreateDto = _mapper.Map<WareHouseCreateDTO>(warehouseCreateVm);
                    await _warehouseService.Create(warehouseCreateDto);
                    return RedirectToAction("GetAllActiveWarehouses");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            return View(warehouseCreateVm);
        }



        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _warehouseService.Delete(id);
                return RedirectToAction("GetAllActiveWarehouses");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("GetAllActiveWarehouses");
            }
        }



        [HttpGet]
        public async Task<IActionResult> UpdateDetails(int id)
        {
            if (await _warehouseService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                WarehouseUpdateVM warehouseUpdateVm = _mapper.Map<WarehouseUpdateVM>(await _warehouseService.GetById(id));
               

                return View(warehouseUpdateVm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetails(WarehouseUpdateVM vm)
        {

            var warehouseUpdateDto = _mapper.Map<WareHouseUpdateDTO>(vm);
            await _warehouseService.Update(warehouseUpdateDto);
            return RedirectToAction("GetAllActiveWarehouses");
        }

    }
}

