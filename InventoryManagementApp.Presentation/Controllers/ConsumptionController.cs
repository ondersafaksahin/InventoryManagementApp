using AutoMapper;
using InventoryManagementApp.Application.DTOs.ConsumptionDTOs;
using InventoryManagementApp.Application.Services.ConsumpitonService;
using InventoryManagementApp.Presentation.Models.ViewModels.ConsumptionVMs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
    public class ConsumptionController : Controller
    {
        IConsumptionService _consumptionService;
        IMapper _mapper;

        public ConsumptionController(IConsumptionService consumptionService, IMapper mapper)
        {
            _consumptionService = consumptionService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllActive()
        {
            var consumptionList = await _consumptionService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var consumptionListVM = _mapper.Map<List<ConsumptionListVM>>(consumptionList);
            return View(consumptionListVM);
        }

        public async Task<IActionResult> GetAll()
        {
            var consumptionList = await _consumptionService.All();
            var consumptionListVM = _mapper.Map<List<ConsumptionListVM>>(consumptionList);
            return View(consumptionListVM);
        }

        #region Create Action
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConsumptionCreateVM consumptionCreateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var consumption = _mapper.Map<ConsumptionCreateDTO>(consumptionCreateVM);
                    await _consumptionService.Create(consumption);
                    return RedirectToAction("GetAllActive");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                }
            }
            return View(consumptionCreateVM);
        }
        #endregion

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _consumptionService.Delete(id);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("GetAllActive");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var consumptionVM = _mapper.Map<ConsumptionUpdateVM>(await _consumptionService.GetById(id));
            return View(consumptionVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ConsumptionUpdateVM consumptionUpdateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _consumptionService.Update(_mapper.Map<ConsumptionUpdateDTO>(consumptionUpdateVM));
                    return RedirectToAction("GetAllActive");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                }
            }
            return View(consumptionUpdateVM);
        }
    }
}
