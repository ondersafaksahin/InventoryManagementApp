using AutoMapper;
using InventoryManagementApp.Application.DTOs.ConversionDTOs;
using InventoryManagementApp.Application.Services.ConversionService;
using InventoryManagementApp.Application.Services.GoodService;
using InventoryManagementApp.Presentation.Models.ViewModels.ConversionVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagementApp.Presentation.Controllers
{
    public class ConversionController : Controller
    {
        IConversionService _conversionService;
        IGoodService _goodService;
        IMapper _mapper;

        public ConversionController(IConversionService conversionService, IMapper mapper, IGoodService goodService)
        {
            _conversionService = conversionService;
            _mapper = mapper;
            _goodService = goodService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAllActive()
        {
            var conversionList = await _conversionService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var conversionListVM = _mapper.Map<List<ConversionListVM>>(conversionList);
            return View(conversionListVM); 
        }

        public async Task<IActionResult> GetAll()
        {
            var conversionList = await _conversionService.All();
            var conversionListVM = _mapper.Map<List<ConversionListVM>>(conversionList);
            return View(conversionListVM);
        }

        #region Create Action
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var conversionCreateVM = new ConversionCreateVM();
            conversionCreateVM.GoodsList = await _goodService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            return View(conversionCreateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConversionCreateVM conversionCreateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var conversion = _mapper.Map<ConversionCreateDTO>(conversionCreateVM);
                    if (User.Identity.IsAuthenticated)
                    {
                        conversion.CreatedBy = User.Identity.Name;
                    }
                    await _conversionService.Create(conversion);
                    return RedirectToAction("GetAllActive");
            }
                catch (Exception ex)
                {
                TempData["error"] = ex.Message;
            }
        }
            else
            {
                TempData["error"] = ModelState.Values.First(x => x.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).Errors[0].ErrorMessage;
            }
            return View(conversionCreateVM);
        }
        #endregion

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _conversionService.Delete(id);  
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
            if (_conversionService.GetById(id) is null)
            {
                return NotFound();
            }
                var conversionVM = _mapper.Map<ConversionUpdateVM>(_conversionService.GetById(id));
                return View(conversionVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ConversionUpdateVM conversionUpdateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _conversionService.Update(_mapper.Map<ConversionUpdateDTO>(conversionUpdateVM));
                    return RedirectToAction("GetAllActive");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                }
            }
            return View(conversionUpdateVM);
        }
    }
}
