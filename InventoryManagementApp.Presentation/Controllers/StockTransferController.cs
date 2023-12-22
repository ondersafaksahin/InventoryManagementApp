using AutoMapper;
using InventoryManagementApp.Application.DTOs.InventoryDTOs;
using InventoryManagementApp.Application.DTOs.SalesOrdesDetailsDTOs;
using InventoryManagementApp.Application.DTOs.StockTransferDTOs;
using InventoryManagementApp.Application.Services.BatchService;
using InventoryManagementApp.Application.Services.GoodService;
using InventoryManagementApp.Application.Services.InventoryService;
using InventoryManagementApp.Application.Services.SalesOrdersDetailsService;
using InventoryManagementApp.Application.Services.StockTransferService;
using InventoryManagementApp.Application.Services.WareHouseService;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Presentation.Models.ViewModels.BatchVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.InventoryVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.SalesOrderDetailsVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.StockTransferVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.Xml;

namespace InventoryManagementApp.Presentation.Controllers
{
    public class StockTransferController : Controller
    {
        private readonly IStockTransferService _stockTransferService;
        private readonly IWareHouseService _wareHouseService;
        private readonly IBatchService _batchService;
        private readonly IGoodService _goodService;
        private readonly IInventoryService _inventoryService;
        private readonly IMapper _mapper;

        public StockTransferController(IStockTransferService stockTransferService, IMapper mapper, IWareHouseService wareHouseService, IGoodService goodService, IInventoryService inventoryService, IBatchService batchService)
        {
            _stockTransferService = stockTransferService;
            _mapper = mapper;
            _wareHouseService = wareHouseService;
            _goodService = goodService;
            _inventoryService = inventoryService;
            _batchService = batchService;
        }
        public IActionResult Index()
        {
            return View();
        }

        private async Task PopulateTransferDetails(List<StockTransferListVM> transfers)
        {
            foreach (var transfer in transfers)
            {
                transfer.GoodName = await _goodService.GetNameById(transfer.GoodId);
                transfer.GoodCode = await _goodService.GetCodeById(transfer.GoodId);
                if (transfer.BatchId != 0)
                {
                    transfer.BatchCode = await _batchService.GetNameById(transfer.BatchId);
                }
                else
                    transfer.BatchCode = null;

                if (transfer.SourceWarehouseID != null)
                {
                    transfer.SourceWarehouseName = await _wareHouseService.GetNameById(transfer.SourceWarehouseID);
                }
                else
                    transfer.SourceWarehouseName = null;

                if (transfer.DestinationWarehouseID != null)
                {
                    transfer.DestinationWarehouseName = await _wareHouseService.GetNameById(transfer.DestinationWarehouseID);
                }
                else
                    transfer.DestinationWarehouseName = null;
            }
        }



        //Listing all stock transfer
        [Route("[controller]/List")]
        public async Task<IActionResult> GetAllStockTransfer()
        {
            List<StockTransferListVM> stockTransferList = _mapper.Map<List<StockTransferListVM>>(await _stockTransferService.All());
            await PopulateTransferDetails(stockTransferList);
            return View(stockTransferList);
        }

        //Adding stock transfer
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            InventoryVM inventoryVm = _mapper.Map<InventoryVM>(await _inventoryService.GetById(id));
            ViewBag.SourceWareHouse = await _wareHouseService.GetNameById(inventoryVm.WarehouseId);
            TempData["SourceWareHouseId"] = inventoryVm.WarehouseId;
            StockTransferCreateVM stockTransferCreateVM = new()
            {
                GoodsList = await GetGoods(),
                WarehouseList = await GetWarehouses()
            };
            return View(stockTransferCreateVM);

        }


        [HttpPost]
        public async Task<IActionResult> Create(StockTransferCreateVM stockTransferCreateVM)
        {
            int sourceWarehouseId = (int)TempData["SourceWareHouseId"];
            stockTransferCreateVM.SourceWarehouseID = sourceWarehouseId;
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                try
                {
                    var stockTransferCreateDto = _mapper.Map<StockTransferCreateDTO>(stockTransferCreateVM);
                    await _stockTransferService.Create(stockTransferCreateDto);
                    return RedirectToAction("GetAllStockTransfer");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            return View(stockTransferCreateVM);
        }



        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _stockTransferService.Delete(id);
                return RedirectToAction("GetAllStockTransfer");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("GetAllStockTransfer");
            }
        }



        [HttpGet]
        public async Task<IActionResult> UpdateDetails(int id)
        {
            if (await _stockTransferService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                StockTransferUpdateVM stockTransferUpdateVM = _mapper.Map<StockTransferUpdateVM>(await _stockTransferService.GetById(id));

                return View(stockTransferUpdateVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetails(StockTransferUpdateVM vm)
        {

            var stockTransferUpdateDto = _mapper.Map<StockTransferUpdateDTO>(vm);
            await _stockTransferService.Update(stockTransferUpdateDto);
            return RedirectToAction("GetAllActiveStockTransfer");
        }

        public async Task<SelectList> GetGoods()
        {
            var goods = await _goodService.All();
            return new SelectList(goods.Select(x => new SelectListItem()
            {
                Value = x.ID.ToString(),
                Text = x.Name
            }),"Value","Text");
        }

        public async Task<SelectList> GetWarehouses()
        {
            var warehouses = await _wareHouseService.All();
            return new SelectList(warehouses.Select(x => new SelectListItem()
            {
                Value = x.ID.ToString(),
                Text = x.Name
            }), "Value", "Text");
        }

        public async Task<IActionResult> GetBatches(int goodId)
        {
            var goodBatches = await _goodService.GetGoodBatches(goodId);
            var batches = goodBatches.Select(x => new SelectListItem { Value = x.Key.ToString(), Text = x.Value });
            return Json(batches);
        }

        public async Task<IActionResult> CompleteTransfer(int stockTransferId)
        {
            try
            {
                await _stockTransferService.CompleteStockTransfer(stockTransferId);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("GetAllStockTransfer");
        }


        public async Task<IActionResult> Reversed(int stockTransferId)
        {
            try
            {
                await _stockTransferService.ReverseStockTransfer(stockTransferId);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("GetAllStockTransfer");
        }



    }
}
