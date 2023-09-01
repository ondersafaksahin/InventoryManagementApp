using AutoMapper;
using InventoryManagementApp.Application.DTOs.SalesOrdesDetailsDTOs;
using InventoryManagementApp.Application.DTOs.StockTransferDTOs;
using InventoryManagementApp.Application.Services.SalesOrdersDetailsService;
using InventoryManagementApp.Application.Services.StockTransferService;
using InventoryManagementApp.Presentation.Models.ViewModels.SalesOrderDetailsVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.StockTransferVMs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
    public class StockTransferController : Controller
    {
        private readonly IStockTransferService _stockTransferService;
        private readonly IMapper _mapper;
        IWebHostEnvironment _webHostEnvironment;

        public StockTransferController(IStockTransferService stockTransferService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _stockTransferService = stockTransferService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }

        //Listing only active stock transfer
        public async Task<IActionResult> GetAllActiveStockTransfer()
        {
            var stockTransferListDTO = await _stockTransferService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var stockTransferListVM = _mapper.Map<List<StockTransferListVM>>(stockTransferListDTO);

            return View(stockTransferListVM);
        }


        //Listing all stock transfer

        public async Task<IActionResult> GetAllStockTransfer()
        {
            List<StockTransferListVM> stockTransferList = _mapper.Map<List<StockTransferListVM>>(await _stockTransferService.All());
            return View(stockTransferList);
        }

        //Adding stock transfer
        [HttpGet]
        public IActionResult Create()
        {
            StockTransferCreateVM stockTransferCreateVM  = new ();

            return View(stockTransferCreateVM);

        }


        [HttpPost]
        public async Task<IActionResult> Create(StockTransferCreateVM stockTransferCreateVM)
        {
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
    }
}
