using AutoMapper;
using InventoryManagementApp.Application.DTOs.BatchDTOs;
using InventoryManagementApp.Application.Services.BatchService;
using InventoryManagementApp.Presentation.Models.ViewModels.BatchVMs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApp.Presentation.Controllers
{
    public class BatchController : Controller
    {
        private readonly IBatchService _batchService;
        private readonly IMapper _mapper;
        IWebHostEnvironment _webHostEnvironment;

        public BatchController(IBatchService batchService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _batchService = batchService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }

        //Listing only active batches
        public async Task<IActionResult> GetAllActiveBatches()
        {
            var batchListDTO = await _batchService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
            var batchListVM = _mapper.Map<List<BatchListVM>>(batchListDTO);

            return View(batchListVM);
        }


        //Listing all bathces

        public async Task<IActionResult> GetAllBatches()
        {
            List<BatchListVM> batchList = _mapper.Map<List<BatchListVM>>(await _batchService.All());
            return View(batchList);
        }

        //Adding Batch
        [HttpGet]
        public IActionResult Create()
        {
            BatchCreateVM batchCreateVm = new BatchCreateVM();

            return View(batchCreateVm);

        }


        [HttpPost]
        public async Task<IActionResult> Create(BatchCreateVM batchCreateVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var batchCreateDto = _mapper.Map<BatchCreateDTO>(batchCreateVM);
                    await _batchService.Create(batchCreateDto);
                    return RedirectToAction("GetAllBatches");
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            return View(batchCreateVM);
        }



        //Delete
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _batchService.Delete(id);
                return RedirectToAction("GetAllBatches");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return RedirectToAction("GetAllBatches");
            }
        }



        [HttpGet]
        public async Task<IActionResult> UpdateDetails(int id)
        {
            if (await _batchService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                BatchUpdateVM batchUpdateVm = _mapper.Map<BatchUpdateVM>(await _batchService.GetById(id));

                return View(batchUpdateVm);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDetails(BatchUpdateVM vm)
        {

            var batchUpdateDto = _mapper.Map<BatchUpdateDTO>(vm);
            await _batchService.Update(batchUpdateDto);
            return RedirectToAction("GetAllActiveBatches");
        }
    }
}
