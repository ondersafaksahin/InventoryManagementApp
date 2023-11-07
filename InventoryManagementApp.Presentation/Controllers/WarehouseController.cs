using AutoMapper;
using InventoryManagementApp.Application.DTOs.ShelfDTOs;
using InventoryManagementApp.Application.DTOs.WareHouseDTOs;
using InventoryManagementApp.Application.Services.ShelfService;
using InventoryManagementApp.Application.Services.WareHouseService;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.Enums;
using InventoryManagementApp.Presentation.Models.ViewModels.ShelfVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.WarehouseVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace InventoryManagementApp.Presentation.Controllers
{
    //[Authorize(Roles = "Admin", "Manager", "Employee")]

    public class WarehouseController : Controller
    {
        private readonly IWareHouseService _warehouseService;
        private readonly IShelfService _shelfService;
        private readonly IMapper _mapper;
        IWebHostEnvironment _webHostEnvironment;

        public WarehouseController(IWareHouseService warehouseService, IMapper mapper, IWebHostEnvironment webHostEnvironment, IShelfService shelfService)
        {
            _warehouseService = warehouseService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _shelfService = shelfService;

        }
        public IActionResult Index()
        {
            return View();
        }

        //Listing only active warehouses
        [Route("[controller]/ListActive")]
        public async Task<IActionResult> GetAllActiveWarehouses()
        {
            var warehouseListDTO = await _warehouseService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var warehouseListVM = _mapper.Map<List<WarehouseListVM>>(warehouseListDTO);

            return View(warehouseListVM);
        }


        //Listing all warehouses
        [Route("[controller]/List")]
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
        public async Task<IActionResult> Delete(int id, bool active)
        {
            try
            {
                await _warehouseService.Delete(id);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            if (active)
            {
                return RedirectToAction("GetAllActiveWarehouses");
            }
            return RedirectToAction("GetAllWarehouses");
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

                warehouseUpdateVm.Shelves = _mapper.Map<List<ShelfListVM>>(await _shelfService.GetDefaults(x => x.WarehouseID == warehouseUpdateVm.ID && x.Status == Status.Active));

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



        [HttpPost]
        public async Task<IActionResult> ShelfCreate(WarehouseUpdateVM vm)
        {

            //if (ModelState.IsValid)
            //{
            try
            {
                var shelfCreateDto = _mapper.Map<ShelfCreateDTO>(vm.newShelf);
                await _shelfService.Create(shelfCreateDto);
                WarehouseUpdateVM warehouse = _mapper.Map<WarehouseUpdateVM>(await _warehouseService.GetById(vm.newShelf.WarehouseID));
                return RedirectToAction("UpdateDetails", warehouse);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }

            return View(vm);
        }


        //DeleteShelf
        public async Task<IActionResult> DeleteShelf(int id, int warehouseid)
        {
            try
            {
                await _shelfService.Delete(id);
                WarehouseUpdateVM warehouse = _mapper.Map<WarehouseUpdateVM>(await _warehouseService.GetById(warehouseid));
                return RedirectToAction("UpdateDetails", warehouse);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                WarehouseUpdateVM warehouse = _mapper.Map<WarehouseUpdateVM>(await _warehouseService.GetById(warehouseid));
                return RedirectToAction("UpdateDetails", warehouse);
            }
        }

        //UpdateShelf
        [HttpGet]
        public async Task<IActionResult> UpdateShelf(int id)
        {
            if (await _shelfService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                ShelfUpdateVM shelfUpdateVM = _mapper.Map<ShelfUpdateVM>(await _shelfService.GetById(id));
                WarehouseUpdateVM warehouse = _mapper.Map<WarehouseUpdateVM>(await _warehouseService.GetById(shelfUpdateVM.WarehouseID));
                warehouse.updateShelf = shelfUpdateVM;
                return PartialView("_ShelfUpdate", warehouse);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShelf(WarehouseUpdateVM vm)
        {

            var shelfUpdateDto = _mapper.Map<ShelfUpdateDTO>(vm.updateShelf);
            await _shelfService.Update(shelfUpdateDto);
            WarehouseUpdateVM warehouse = _mapper.Map<WarehouseUpdateVM>(await _warehouseService.GetById(shelfUpdateDto.WarehouseID));
            return RedirectToAction("UpdateDetails", warehouse);
        }
    }
}

