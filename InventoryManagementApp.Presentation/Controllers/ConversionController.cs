using AutoMapper;
using InventoryManagementApp.Application.DTOs.ConversionDTOs;
using InventoryManagementApp.Application.Services.ConversionService;
using InventoryManagementApp.Application.Services.GoodService;
using InventoryManagementApp.Presentation.Models.ViewModels.BrandVMs;
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

        [Route("[controller]/ListActive")]
        public async Task<IActionResult> GetAllActive()
        {
            var conversionList = await _conversionService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var conversionListVM = _mapper.Map<List<ConversionListVM>>(conversionList);
            foreach (var item in conversionListVM)
            {
                item.Good = _goodService.GetById(item.GoodID).Result.Name;
            }
            return View(conversionListVM); 
        }

        [Route("[controller]/List")]
        public async Task<IActionResult> GetAll()
        {
            var conversionList = await _conversionService.All();
            var conversionListVM = _mapper.Map<List<ConversionListVM>>(conversionList);
            foreach (var item in conversionListVM)
            {
                item.Good = _goodService.GetById(item.GoodID).Result.Name;
            }
            return View(conversionListVM);
        }

        #region Create Action
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var conversionCreateVM = new ConversionCreateVM();
            conversionCreateVM.GoodsList = await GetGoods();
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
                    return RedirectToAction("ListActive");
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

        public async Task<IActionResult> Delete(int id,bool active)
        {
            try
            {
                await _conversionService.Delete(id);  
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            if (active)
            {
                return RedirectToAction("GetAllActive");
            }
            return RedirectToAction("GetAll");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var conversion = await _conversionService.GetById(id);
            var conversionVM = _mapper.Map<ConversionUpdateVM>(conversion);
            ViewBag.goodName = (await _goodService.GetById(conversion.GoodID)).Name;
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

        public async Task<IActionResult> Details(int id)
        {
            if (await _conversionService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                ConversionVM conversionVM = _mapper.Map<ConversionVM>(await _conversionService.GetById(id));
                ViewBag.goodName = (await _goodService.GetById(conversionVM.GoodID)).Name;

                return View(conversionVM);
            }
        }

        private async Task<SelectList> GetGoods() {
            var goods = await _goodService.All();
            return new SelectList(goods.Select(x => new SelectListItem
            {
                Value = x.ID.ToString(),
                Text = x.Name
            }), "Value", "Text");
        }
    }
}
