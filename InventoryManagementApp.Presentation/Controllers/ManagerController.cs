using AutoMapper;
using InventoryManagementApp.Application.DTOs.ManagerDTOs;
using InventoryManagementApp.Application.Services.ManagerService;
using InventoryManagementApp.Presentation.Models.ViewModels.ManagerVMs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers

{   
    //[Authorize(Roles = "Admin", "Manager", "Employee")]
    public class ManagerController : Controller
    {

        private readonly IManagerService _managerService;
        private readonly IMapper _mapper;
        IWebHostEnvironment _webHostEnvironment;

        public ManagerController(IManagerService managerService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _managerService = managerService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult Index()
        {
            return View();
        }

        //Listing only active managers
        public async Task<IActionResult> GetAllActiveManagers()
        {
            var managerListDTO = await _managerService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var managerListVM = _mapper.Map<List<ManagerListVM>>(managerListDTO);

            return View(managerListVM);
        }


        //Listing all managers

        public async Task<IActionResult> GetAllManagers()
        {
            List<ManagerListVM> managerList = _mapper.Map<List<ManagerListVM>>(await _managerService.All());
            return View(managerList);
        }

        //Adding Manager
        [HttpGet]
        public IActionResult Create()
        {
            ManagerCreateVM managerCreateVm = new ManagerCreateVM();

            return View(managerCreateVm);

        }


        [HttpPost]
        public async Task<IActionResult> Create(ManagerCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {


                    string wwwrootDosyaYolu = _webHostEnvironment.WebRootPath;
                    string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName);
                    string dosyaUzantisi = Path.GetExtension(Request.Form.Files[0].FileName);
                    string tamDosyaAdi = $"{dosyaAdi}_{Guid.NewGuid()}{dosyaUzantisi}";
                    string yeniDosyaYolu = Path.Combine($"{wwwrootDosyaYolu}/images/{tamDosyaAdi}");

                    using (var fileStream = new FileStream(yeniDosyaYolu, FileMode.Create))
                    {
                        Request.Form.Files[0].CopyTo(fileStream);

                    }

                    //vm.picture = tamDosyaAdi;
                }

                else
                {
                    //vm.picture = vm.picture;
                }
                try
                {
                    var managerCreateDto = _mapper.Map<ManagerCreateDTO>(vm);
                    await _managerService.Create(managerCreateDto);
                    return RedirectToAction("GetAllManagers");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            return View(vm);
        }

        //Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _managerService.Delete(id);
                return RedirectToAction("GetAllManagers");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("GetAllManagers");
            }
        }



        [HttpGet]
        public async Task<IActionResult> UpdateDetails(Guid id)
        {
            if (await _managerService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                ManagerUpdateVM managerUpdateVm = _mapper.Map<ManagerUpdateVM>(await _managerService.GetById(id));

                return View(managerUpdateVm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetails(ManagerUpdateVM vm)
        {

            if (Request.Form.Files.Count > 0)
            {

                string wwwrootDosyaYolu = _webHostEnvironment.WebRootPath;
                string dosyaAdi = Path.GetFileNameWithoutExtension(Request.Form.Files[0].FileName);
                string dosyaUzantisi = Path.GetExtension(Request.Form.Files[0].FileName);
                string tamDosyaAdi = $"{dosyaAdi}_{Guid.NewGuid()}{dosyaUzantisi}";
                string yeniDosyaYolu = Path.Combine($"{wwwrootDosyaYolu}/images/{tamDosyaAdi}");

                using (var fileStream = new FileStream(yeniDosyaYolu, FileMode.Create))
                {
                    Request.Form.Files[0].CopyTo(fileStream);

                }

                //vm.picture = tamDosyaAdi;
            }

            else
            {
                //vm.picture = vm.picture;
            }

            var managerUpdateDTO = _mapper.Map<ManagerUpdateDTO>(vm);
            await _managerService.Update(managerUpdateDTO);
            return RedirectToAction("GetAllActiveManagers");
        }
    }
}
