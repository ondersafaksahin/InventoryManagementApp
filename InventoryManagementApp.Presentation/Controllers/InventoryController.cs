using AutoMapper;
using InventoryManagementApp.Application.DTOs.InventoryDTOs;
using InventoryManagementApp.Application.Services.GoodService;
using InventoryManagementApp.Application.Services.InventoryService;
using InventoryManagementApp.Application.Services.WareHouseService;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Presentation.Models.ViewModels.CategoryVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.InventoryVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagementApp.Presentation.Controllers
{
    public class InventoryController : Controller
    {

        private readonly IInventoryService _inventoryService;
        private readonly IGoodService _goodService;
        private readonly IWareHouseService _wareHouseService;
        private readonly IMapper _mapper;

        public InventoryController(IInventoryService inventoryService, IMapper mapper,IGoodService goodService, IWareHouseService wareHouseService)
        {
            _inventoryService = inventoryService;
            _goodService = goodService;
            _wareHouseService = wareHouseService;
            _mapper = mapper;
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
            var unitType = unit.FirstOrDefault().StockingUnit.ToString();
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
            return View(inventoryList);
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


        private async Task<SelectList> GetGoods(int? goodId = null) {
            var goodsList = await _goodService.All();
            var goodItems = goodsList.Where(x => x.ID == goodId).Select(x => new SelectListItem
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

    }
}
