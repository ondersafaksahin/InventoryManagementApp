using AutoMapper;
using InventoryManagementApp.Application.DTOs.BatchDTOs;
using InventoryManagementApp.Application.DTOs.SalesOrdesDetailsDTOs;
using InventoryManagementApp.Application.Services.BatchService;
using InventoryManagementApp.Application.Services.SalesOrdersDetailsService;
using InventoryManagementApp.Presentation.Models.ViewModels.BatchVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.SalesOrderDetailsVMs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
    public class SalesOrderDetailsController : Controller
    {
        private readonly ISalesOrdersDetailsService _salesOrdersDetailsService;
        private readonly IMapper _mapper;
        IWebHostEnvironment _webHostEnvironment;

        public SalesOrderDetailsController(ISalesOrdersDetailsService salesOrdersDetailsService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _salesOrdersDetailsService = salesOrdersDetailsService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }

        //Listing only active batches
        public async Task<IActionResult> GetAllActiveSalesOrdersDetails()
        {
            var salesOrdersDetailsListDTO = await _salesOrdersDetailsService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var salesOrdersDetailsListVM = _mapper.Map<List<SalesOrderDetailsListVM>>(salesOrdersDetailsListDTO);

            return View(salesOrdersDetailsListVM);
        }


        //Listing all bathces

        public async Task<IActionResult> GetAllSalesOrdersDetails()
        {
            List<SalesOrderDetailsListVM> salesOrdersDetailsList = _mapper.Map<List<SalesOrderDetailsListVM>>(await _salesOrdersDetailsService.All());
            return View(salesOrdersDetailsList);
        }

        //Adding Batch
        [HttpGet]
        public IActionResult Create()
        {
            SalesOrderDetailsCreateVM salesOrderDetailsCreateVM = new SalesOrderDetailsCreateVM();

            return View(salesOrderDetailsCreateVM);

        }


        [HttpPost]
        public async Task<IActionResult> Create(SalesOrderDetailsCreateVM salesOrderDetailsCreateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var salesOrderDetailsCreateDto = _mapper.Map<SalesOrdersDetailsCreateDTO>(salesOrderDetailsCreateVM);
                    await _salesOrdersDetailsService.Create(salesOrderDetailsCreateDto);
                    return RedirectToAction("GetAllSalesOrdersDetails");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            return View(salesOrderDetailsCreateVM);
        }



        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _salesOrdersDetailsService.Delete(id);
                return RedirectToAction("GetAllSalesOrdersDetails");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("GetAllSalesOrdersDetails");
            }
        }



        [HttpGet]
        public async Task<IActionResult> UpdateDetails(int id)
        {
            if (await _salesOrdersDetailsService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                SalesOrderDetailsUpdateVM salesOrderDetailsUpdateVM = _mapper.Map<SalesOrderDetailsUpdateVM>(await _salesOrdersDetailsService.GetById(id));

                return View(salesOrderDetailsUpdateVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetails(SalesOrderDetailsUpdateVM vm)
        {

            var salesOrderDetailsUpdateDto = _mapper.Map<SalesOrdersDetailsUpdateDTO>(vm);
            await _salesOrdersDetailsService.Update(salesOrderDetailsUpdateDto);
            return RedirectToAction("GetAllActiveSalesOrdersDetails");
        }
    }
}
