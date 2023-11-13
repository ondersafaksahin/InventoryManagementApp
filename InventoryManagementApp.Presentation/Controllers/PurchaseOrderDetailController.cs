using AutoMapper;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDetailDTOs;
using InventoryManagementApp.Application.Services.PurchaseOrderDetailService;
using InventoryManagementApp.Presentation.Models.ViewModels.PurchaseOrderDetailVMs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
    //[Authorize(Roles = "Admin", "Manager", "Employee")]

    public class PurchaseOrderDetailController : Controller
    {
        
            private readonly IPurchaseOrderDetailService _purchaseOrderDetailService;
            private readonly IMapper _mapper;
            IWebHostEnvironment _webHostEnvironment;

            public PurchaseOrderDetailController(IPurchaseOrderDetailService purchaseOrderDetailService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
            {
                _purchaseOrderDetailService = purchaseOrderDetailService;
                _mapper = mapper;
                _webHostEnvironment = webHostEnvironment;

            }
            public IActionResult Index()
            {
                return View();
            }

            //Listing only active PurchaseOrderDetails
            public async Task<IActionResult> GetAllActivePurchaseOrderDetails()
            {
                var purchaseOrderDetailsListDTO = await _purchaseOrderDetailService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
                var purchaseOrderDetailsListVM = _mapper.Map<List<PurchaseOrderDetailListVM>>(purchaseOrderDetailsListDTO);

                return View(purchaseOrderDetailsListVM);
            }


            //Listing all PurchaseOrderDetails

            public async Task<IActionResult> GetAllPurchaseOrderDetails()
            {
                List<PurchaseOrderDetailListVM> purchaseOrderDetailsList = _mapper.Map<List<PurchaseOrderDetailListVM>>(await _purchaseOrderDetailService.All());
                return View(purchaseOrderDetailsList);
            }

            //Adding PurchaseOrderDetails
            [HttpGet]
            public IActionResult Create()
            {
                PurchaseOrderDetailCreateVM purchaseOrderDetailCreateVm = new PurchaseOrderDetailCreateVM();

                return View(purchaseOrderDetailCreateVm);

            }


            [HttpPost]
            public async Task<IActionResult> Create(PurchaseOrderDetailCreateVM purchaseOrderDetailCreateVm)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        var purchaseOrderDetailCreateDto = _mapper.Map<PurchaseOrderDetailCreateDTO>(purchaseOrderDetailCreateVm);
                        await _purchaseOrderDetailService.Create(purchaseOrderDetailCreateDto);
                        return RedirectToAction("GetAllPurchaseOrderDetails");
                    }
                    catch (Exception ex)
                    {
                        TempData["error"] = ex.Message;
                    }
                }
                return View(purchaseOrderDetailCreateVm);
            }



            //Delete
            public async Task<IActionResult> Delete(int id)
            {
                try
                {
                    await _purchaseOrderDetailService.Delete(id);
                    return RedirectToAction("GetAllPurchaseOrderDetails");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                    return RedirectToAction("GetAllPurchaseOrderDetails");
                }
            }



            [HttpGet]
            public async Task<IActionResult> UpdateDetails(int id)
            {
                if (await _purchaseOrderDetailService.GetById(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    PurchaseOrderDetailUpdateVM purchaseOrderDetailUpdateVm = _mapper.Map<PurchaseOrderDetailUpdateVM>(await _purchaseOrderDetailService.GetById(id));

                    return View(purchaseOrderDetailUpdateVm);
                }
            }

            [HttpPost]
            public async Task<IActionResult> UpdateDetails(PurchaseOrderDetailUpdateVM vm)
            {

                var purchaseOrderDetailUpdateDto = _mapper.Map<PurchaseOrderDetailUpdateDTO>(vm);
                await _purchaseOrderDetailService.Update(purchaseOrderDetailUpdateDto);
                return RedirectToAction("GetAllPurchaseOrderDetails");
            }

        }
    
}
