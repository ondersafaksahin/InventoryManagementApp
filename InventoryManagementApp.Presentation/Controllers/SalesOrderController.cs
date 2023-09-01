using AutoMapper;
using InventoryManagementApp.Application.DTOs.BatchDTOs;
using InventoryManagementApp.Application.DTOs.SalesOrdesDTOs;
using InventoryManagementApp.Application.Services.BatchService;
using InventoryManagementApp.Application.Services.SalesOrderService;
using InventoryManagementApp.Presentation.Models.ViewModels.BatchVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.SalesOrderVMs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
    public class SalesOrderController : Controller
    {
        private readonly ISalesOrderService _salesOrderService;
        private readonly IMapper _mapper;
        IWebHostEnvironment _webHostEnvironment;

        public SalesOrderController(ISalesOrderService salesOrderService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _salesOrderService = salesOrderService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }

        //Listing only active batches
        public async Task<IActionResult> GetAllActiveSalesOrders()
        {
            var salesOrderListDTO = await _salesOrderService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var salesOrdeListVM = _mapper.Map<List<SalesOrderListVM>>(salesOrderListDTO);

            return View(salesOrdeListVM);
        }


        //Listing all bathces

        public async Task<IActionResult> GetAllSalesOrders()
        {
            List<SalesOrderListVM> orderList = _mapper.Map<List<SalesOrderListVM>>(await _salesOrderService.All());
            return View(orderList);
        }

        //Adding Batch
        [HttpGet]
        public IActionResult Create()
        {
            SalesOrderCreateVM salesOrderCreateVM = new SalesOrderCreateVM();

            return View(salesOrderCreateVM);

        }


        [HttpPost]
        public async Task<IActionResult> Create(SalesOrderCreateVM salesOrderCreateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var salesOrderCreateDto = _mapper.Map<SalesOrderCreateDTO>(salesOrderCreateVM);
                    await _salesOrderService.Create(salesOrderCreateDto);
                    return RedirectToAction("GetAllSalesOrders");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            return View(salesOrderCreateVM);
        }



        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _salesOrderService.Delete(id);
                return RedirectToAction("GetAllSalesOrders");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("GetAllSalesOrders");
            }
        }



        [HttpGet]
        public async Task<IActionResult> UpdateDetails(int id)
        {
            if (await _salesOrderService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                SalesOrderUpdateVM salesOrderUpdateVM = _mapper.Map<SalesOrderUpdateVM>(await _salesOrderService.GetById(id));

                return View(salesOrderUpdateVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetails(SalesOrderUpdateVM vm)
        {

            var salesOrderhUpdateDto = _mapper.Map<SalesOrderUpdateDTO>(vm);
            await _salesOrderService.Update(salesOrderhUpdateDto);
            return RedirectToAction("GetAllActiveSalesOrders");
        }
    }
}
