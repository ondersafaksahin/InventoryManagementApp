using AutoMapper;
using InventoryManagementApp.Application.DTOs.EmployeeDTOs;
using InventoryManagementApp.Application.Services.EmployeeService;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Presentation.Models.ViewModels.EmployeeVMs;
using InventoryManagementApp.Presentation.Models.ViewModels.ManagerVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace InventoryManagementApp.Presentation.Controllers
{
    //[Authorize(Roles = "Admin, Manager, Employee")]

    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        IWebHostEnvironment _webHostEnvironment;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Listing only active employees
        public async Task<IActionResult> GetAllActiveEmployees()
        {
            var employeeListDTO = await _employeeService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var employeeListVM = _mapper.Map<List<ManagerListVM>>(employeeListDTO);

            return View(employeeListVM);
        }


        //Listing all employees

        public async Task<IActionResult> GetAllEmployees()
        {
            List<EmployeeListVM> employeeList = _mapper.Map<List<EmployeeListVM>>(await _employeeService.All());
            return View(employeeList);
		}

		//Adding employee
        [HttpGet]
		//[Authorize(Roles = "Admin,Manager")]
		public IActionResult Create()
        {
            EmployeeCreateVM employeeCreateVm = new EmployeeCreateVM();

            return View(employeeCreateVm);

        }


        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateVM vm)
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
                    var employeeCreateDto = _mapper.Map<EmployeeCreateDTO>(vm);
                    await _employeeService.Create(employeeCreateDto);
                    return RedirectToAction("GetAllEmployees");
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
                await _employeeService.Delete(id);
                return RedirectToAction("GetAllEmployees");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("GetAllEmployees");
            }
        }



        [HttpGet]
        public async Task<IActionResult> UpdateDetails(Guid id)
        {
            if (await _employeeService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                EmployeeUpdateVM employeeUpdateVm = _mapper.Map<EmployeeUpdateVM>(await _employeeService.GetById(id));

                return View(employeeUpdateVm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetails(EmployeeUpdateVM vm)
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

            var employeeUpdateDTO = _mapper.Map<EmployeeUpdateDTO>(vm);
            await _employeeService.Update(employeeUpdateDTO);
            return RedirectToAction("GetAllActiveEmployees");
        }
    }
}

