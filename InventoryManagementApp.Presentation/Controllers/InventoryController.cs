using AutoMapper;
using InventoryManagementApp.Application.DTOs.BatchDTOs;
using InventoryManagementApp.Application.DTOs.BrandDTOs;
using InventoryManagementApp.Application.DTOs.InventoryDTOs;
using InventoryManagementApp.Application.Services.BatchService;
using InventoryManagementApp.Application.Services.GoodService;
using InventoryManagementApp.Application.Services.InventoryService;
using InventoryManagementApp.Application.Services.WareHouseService;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Presentation.Models.ViewModels.BrandVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.CategoryVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.InventoryVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.Xml;

namespace InventoryManagementApp.Presentation.Controllers
{
    public class InventoryController : Controller
    {

        private readonly IInventoryService _inventoryService;
        private readonly IGoodService _goodService;
        private readonly IWareHouseService _wareHouseService;
        private readonly IBatchService _batchService;
        private readonly IMapper _mapper;

        public InventoryController(IInventoryService inventoryService, IMapper mapper,IGoodService goodService, IWareHouseService wareHouseService,IBatchService batchService)
        {
            _inventoryService = inventoryService;
            _goodService = goodService;
            _wareHouseService = wareHouseService;
            _mapper = mapper;
            _batchService = batchService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetGoodUnit(int goodId)
        {
            var unit = await _goodService.GetDefaults(x => x.ID == goodId);

            if(unit == null)
            {
                return null;
            }
            var unitType = unit.First().StockingUnit.ToString();
            return Json(unitType);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Goods = await GetGoods();
            ViewBag.Warehouses = await GetWarehouse();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InventoryCreateVM inventoryCreateVM)
        {
            var inventoryCreateDto = _mapper.Map<InventoryCreateDTO>(inventoryCreateVM);
            if (inventoryCreateVM.BatchCode is not null)
            {
                try
                {
                    var batch = _mapper.Map<BatchCreateDTO>(inventoryCreateVM);
                    var batchId = await _batchService.Create(batch);
                    inventoryCreateDto.BatchId = batchId;
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                }
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _inventoryService.Create(inventoryCreateDto);
                    return RedirectToAction("GetAllInventories");
                }
                catch (Exception ex)
                {
                    TempData["Error"]=ex.Message;
                }
            }
            else
            {
                TempData["Error"] = ModelState.Values.First(x => x.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).Errors[0].ErrorMessage;
            }
            return View(inventoryCreateVM);
        }


        //Listing all inventory
        [Route("[controller]/List")]
        public async Task<IActionResult> GetAllInventories()
        {
            List<InventoryListVM> inventoryList = _mapper.Map<List<InventoryListVM>>(await _inventoryService.All());
            
            foreach (var inventory in inventoryList)
            {
                inventory.GoodName = await _goodService.GetNameById(inventory.GoodId);
                
                if (inventory.WarehouseId != null)
                {
                    inventory.WarehouseName = await _wareHouseService.GetNameById(inventory.WarehouseId);
                }
                else
                    inventory.WarehouseName = null;

                if (inventory.BatchId != null)
                {
                    inventory.BatchCode = await _batchService.GetNameById(inventory.BatchId);
                }
                else
                    inventory.BatchCode = null;
            }
            return View(inventoryList);
        }

        public async Task<IActionResult> GetAllInventoriesWithoutBatch()
        {
            List<InventoryListVM> inventoryList = _mapper.Map<List<InventoryListVM>>(await _inventoryService.All());
            foreach (var inventory in inventoryList)
            {
                inventory.GoodName = await _goodService.GetNameById(inventory.GoodId);
                if (inventory.WarehouseId != null)
                {
                    inventory.WarehouseName = await _wareHouseService.GetNameById(inventory.WarehouseId);
                }
                else
                    inventory.WarehouseName = null;
            }
            return PartialView("_ListInventoriesWithoutBatch", inventoryList);
        }

        public async Task<IActionResult> InventoriesOfGood()
        {
            List<InventoryListVM> inventoryList = _mapper.Map<List<InventoryListVM>>(await _inventoryService.All());

            var goodsList = await _goodService.All();

            var groupedInventoryByGoodId = inventoryList
                .GroupBy(i => i.GoodId)
                .Select(group => new
                {
                    GoodId = group.Key,
                    GoodCode=goodsList.FirstOrDefault(x=>x.ID==group.Key)?.Code,
                    GoodName = goodsList.FirstOrDefault(x => x.ID == group.Key)?.Name,
                    TotalAmount = group.Sum(i => i.Amount),
                    Items = group.ToList()
                })
                .OrderBy(result => result.GoodId)
                .ToList();

            ViewBag.GroupedInventoryByGoodId = groupedInventoryByGoodId;
            return PartialView("_InventoryPartial", inventoryList);
        }

        public async Task<IActionResult> InventoriesOfWarehouse()
        {
            List<InventoryListVM> inventoryList = _mapper.Map<List<InventoryListVM>>(await _inventoryService.All());

            var warehouseList = await _wareHouseService.All();
            var groupedInventoryByWarehouseId = inventoryList
                .GroupBy(i => i.WarehouseId)
                .Select(group => new
                {
                    WarehouseId = group.Key,
                    WarehouseName = warehouseList.FirstOrDefault(x => x.ID == group.Key)?.Name,
                    TotalAmount = group.Sum(i => i.Amount),
                    Items = group.ToList()
                })
                .OrderBy(result => result.WarehouseId)
                .ToList();

            ViewBag.GroupedInventoryByWarehouseId = groupedInventoryByWarehouseId;
            return PartialView("_InventoryWarehouse", inventoryList);
        }


        private async Task<SelectList> GetGoods() {
            var goodsList = await _goodService.All();
            var goodItems = goodsList.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Name
            }).ToList();

            return new SelectList(goodItems, "Value", "Text");
        }

        private async Task<SelectList> GetWarehouse()
        {
            var getWarehouses = await _wareHouseService.All();
            return new SelectList(getWarehouses.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Name
            }), "Value", "Text");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var inventory = await _inventoryService.GetById(id);
            var inventoryUpdateVM = _mapper.Map<InventoryUpdateVM>(inventory);
            inventoryUpdateVM.GoodName= (await _goodService.GetById(inventory.GoodId)).Name;
            inventoryUpdateVM.Unit = (await _goodService.GetById(inventory.GoodId)).StockingUnit.ToString();
            inventoryUpdateVM.WarehouseName = inventory.WarehouseId is null?null:(await _wareHouseService.GetById((int)inventory.WarehouseId)).Name;
            ViewBag.Warehouses = await GetWarehouse();

            return View(inventoryUpdateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InventoryUpdateVM inventoryUpdateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var inventoryDto = _mapper.Map<InventoryUpdateDTO>(inventoryUpdateVM);
                    await _inventoryService.Update(inventoryDto);
                    return RedirectToAction("GetAllInventories");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                }
            }
            return View(inventoryUpdateVM);
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _inventoryService.Delete(id);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("GetAllInventories");
        }

    }
}
