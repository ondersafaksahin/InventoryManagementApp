using AutoMapper;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Application.DTOs.ShelfDTOs;
using InventoryManagementApp.Application.Services.GoodService;
using InventoryManagementApp.Application.Services.ShelfService;
using InventoryManagementApp.Presentation.Models.ViewModels.GoodVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ShelfVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace InventoryManagementApp.Presentation.Controllers
{
    //[Authorize(Roles = "Admin", "Manager", "Employee")]
    public class ShelfController : Controller
    {

        private readonly IShelfService _shelfService;
        private readonly IMapper _mapper;
        IWebHostEnvironment _webHostEnvironment;

        public ShelfController(IShelfService shelfService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _shelfService = shelfService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }

        //Listing only active shelves
        public async Task<IActionResult> GetAllActiveShelves()
        {
            var shelfListDTO = await _shelfService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var shelfListVM = _mapper.Map<List<ShelfListVM>>(shelfListDTO);

            return View(shelfListVM);
        }


        //Listing all shelves

        public async Task<IActionResult> GetAllShelves()
        {
            List<ShelfListVM> shelfList = _mapper.Map<List<ShelfListVM>>(await _shelfService.All());
            return View(shelfList);
        }

        //Adding Shelf
        [HttpGet]
        public IActionResult Create()
        {
            ShelfCreateVM shelfCreateVm = new ShelfCreateVM();

            return View(shelfCreateVm);

        }


        [HttpPost]
        public async Task<IActionResult> Create(ShelfCreateVM shelfCreateVm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var shelfCreateDto = _mapper.Map<ShelfCreateDTO>(shelfCreateVm);
                    await _shelfService.Create(shelfCreateDto);
                    return RedirectToAction("GetAllShelves");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            return View(shelfCreateVm);
        }



        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _shelfService.Delete(id);
                return RedirectToAction("GetAllShelves");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("GetAllShelves");
            }
        }



        [HttpGet]
        public async Task<IActionResult> UpdateDetails(int id)
        {
            if (await _shelfService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                ShelfUpdateVM shelfUpdateVm = _mapper.Map<ShelfUpdateVM>(await _shelfService.GetById(id));
                //burada getById shelfDTO dönüyor.
                //onun update olarak dönecek şekilde mi değiştirilerim?
                //shelfDTO ile ShelfUpdateVm mi mapleyelim?

                return View(shelfUpdateVm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetails(ShelfUpdateVM vm)
        {

            var shelfUpdateDto = _mapper.Map<ShelfUpdateDTO>(vm);
            await _shelfService.Update(shelfUpdateDto);
            return RedirectToAction("GetAllActiveShelves");
        }

    }
}
