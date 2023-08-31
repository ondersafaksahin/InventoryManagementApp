using AutoMapper;
using InventoryManagementApp.Application.DTOs.ProductionOrderDTOs;
using InventoryManagementApp.Application.Services.ProductionOrderService;
using InventoryManagementApp.Presentation.Models.ViewModels.ProductionOrderVMs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
    public class ProductionOrderController : Controller
    {
        IProductionOrderService _productionOrderService;
        IMapper _mapper;

        public ProductionOrderController(IProductionOrderService productionOrderService, IMapper mapper)
        {
            _productionOrderService = productionOrderService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllActiveProductionOrders()
        {
            var pOrderList = _mapper.Map<List<ProductionOrderListVM>>(await _productionOrderService.GetDefaults(x => x.Status == Domain.Enums.Status.Active));
            return View(pOrderList);
        }

        public async Task<IActionResult> GetAllProductionOrders()
        {
            var pOrderList = _mapper.Map<List<ProductionOrderListVM>>(await _productionOrderService.All());
            return View(pOrderList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductionOrderCreateVM pOrderCreateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var pOrderInfo = _mapper.Map<ProductionOrderCreateDTO>(pOrderCreateVM);
                    await _productionOrderService.Create(pOrderInfo);
                    return RedirectToAction("GetAllActiveProductionOrders");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                }
            }
            return View(pOrderCreateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int pOrderId)
        {
            try
            {
                await _productionOrderService.Delete(pOrderId);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("GetAllActiveProductionOrders");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int pOrderId)
        {
            var pOrderVM = _mapper.Map<ProductionOrderUpdateVM>(await _productionOrderService.GetById(pOrderId));
            return View(pOrderVM);
        }


        [HttpPost]
        public async Task<IActionResult> Update(ProductionOrderUpdateVM pOrderUpdateVM)
        {
            var pOrderdto = _mapper.Map<ProductionOrderUpdateDTO>(pOrderUpdateVM);
            if (ModelState.IsValid)
            {
                try
                {
                    await _productionOrderService.Update(pOrderdto);
                    return RedirectToAction("GetAllActiveProductionOrders");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                }
            }
            return View(pOrderUpdateVM);
        }
    }
}