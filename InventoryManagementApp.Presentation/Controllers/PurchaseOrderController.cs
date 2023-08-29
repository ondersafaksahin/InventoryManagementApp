using AutoMapper;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDTOs;
using InventoryManagementApp.Application.DTOs.ShelfDTOs;
using InventoryManagementApp.Application.Services.PurchaseOrderService;
using InventoryManagementApp.Application.Services.ShelfService;
using InventoryManagementApp.Presentation.Models.ViewModels.PurchaseOrderVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ShelfVMs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
    //[Authorize(Roles = "Admin", "Manager", "Employee")]

    public class PurchaseOrderController : Controller
    {
        private readonly IPurchaseOrderService _purchaseOrderService;
        private readonly IMapper _mapper;
        IWebHostEnvironment _webHostEnvironment;

        public PurchaseOrderController(IPurchaseOrderService purchaseOrderService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _purchaseOrderService = purchaseOrderService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }

        //Listing only active purchaseOrders
        public async Task<IActionResult> GetAllActivePurchaseOrders()
        {
            var purchaseOrderListDTO = await _purchaseOrderService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var purchaseOrderListVM = _mapper.Map<List<PurchaseOrderListVM>>(purchaseOrderListDTO);

            return View(purchaseOrderListVM);
        }


        //Listing all purchaseOrders

        public async Task<IActionResult> GetAllPurchaseOrders()
        {
            List<PurchaseOrderListVM> purchaseOrdersList = _mapper.Map<List<PurchaseOrderListVM>>(await _purchaseOrderService.All());
            return View(purchaseOrdersList);
        }

        //Adding purchaseOrder
        [HttpGet]
        public IActionResult Create()
        {
            PurchaseOrderCreateVM purchaseOrderCreateVm = new PurchaseOrderCreateVM();

            return View(purchaseOrderCreateVm);

        }


        [HttpPost]
        public async Task<IActionResult> Create(PurchaseOrderCreateVM purchaseOrderCreateVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var purchaseOrderCreateDto = _mapper.Map<PurchaseOrderCreateDTO>(purchaseOrderCreateVm);
                    await _purchaseOrderService.Create(purchaseOrderCreateDto);
                    return RedirectToAction("GetAllShelves");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            return View(purchaseOrderCreateVm);
        }



        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _purchaseOrderService.Delete(id);
                return RedirectToAction("GetAllPurchaseOrders");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("GetAllPurchaseOrders");
            }
        }



        [HttpGet]
        public async Task<IActionResult> UpdateDetails(int id)
        {
            if (await _purchaseOrderService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                PurchaseOrderUpdateVM purchaseOrderUpdateVm = _mapper.Map<PurchaseOrderUpdateVM>(await _purchaseOrderService.GetById(id));
                //burada getById shelfDTO dönüyor.
                //onun update olarak dönecek şekilde mi değiştirilerim?
                //shelfDTO ile ShelfUpdateVm mi mapleyelim?

                return View(purchaseOrderUpdateVm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetails(PurchaseOrderUpdateVM vm)
        {

            var purchaseOrdersUpdateDto = _mapper.Map<PurchaseOrderUpdateDTO>(vm);
            await _purchaseOrderService.Update(purchaseOrdersUpdateDto);
            return RedirectToAction("GetAllPurchaseOrders");
        }

    }
}

