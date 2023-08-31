using AutoMapper;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDetailsDTOs;
using InventoryManagementApp.Application.Services.BillOfMaterialsDetailsService;
using InventoryManagementApp.Presentation.Models.ViewModels.BillOfMaterialsDetailsVMs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
    public class BillOfMaterialsDetailsController : Controller
    {
        IBillOfMaterialsDetailsService _billOfMatieralsDetailsService;
        IMapper _mapper;

        public BillOfMaterialsDetailsController(IBillOfMaterialsDetailsService billOfMatieralsDetailsService, IMapper mapper)
        {
            _billOfMatieralsDetailsService = billOfMatieralsDetailsService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BillOfMaterialsDetailsCreateVM bomDetailCreateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var bomDetailInfo = _mapper.Map<BillOfMaterialsDetailsCreateDTO>(bomDetailCreateVM);
                    await _billOfMatieralsDetailsService.Create(bomDetailInfo);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                }
            }
            return View(bomDetailCreateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int bomDetailId)
        {
            try
            {
                await _billOfMatieralsDetailsService.Delete(bomDetailId);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int bomDetailId)
        {
            var bomDetailVM = _mapper.Map<BillOfMaterialsDetailsUpdateVM>(await _billOfMatieralsDetailsService.GetById(bomDetailId));
            return View(bomDetailVM);
        }


        [HttpPost]
        public async Task<IActionResult> Update(BillOfMaterialsDetailsUpdateVM bomDetailUpdateVM)
        {
            var bomDetaildto = _mapper.Map<BillOfMaterialsDetailsUpdateDTO>(bomDetailUpdateVM);
            if (ModelState.IsValid)
            {
                try
                {
                    await _billOfMatieralsDetailsService.Update(bomDetaildto);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                }
            }
            return View(bomDetailUpdateVM);
        }
    }
}