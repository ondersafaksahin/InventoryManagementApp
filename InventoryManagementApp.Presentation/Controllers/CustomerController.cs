using AutoMapper;
using InventoryManagementApp.Application.DTOs.CustomerDTOs;
using InventoryManagementApp.Application.Services.CustomerService;
using InventoryManagementApp.Presentation.Models.ViewModels.CustomerVMs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InventoryManagementApp.Presentation.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ICustomerService _customerService;
		private readonly IMapper _mapper;
		public CustomerController(ICustomerService customerService, IMapper mapper)
		{
			_customerService = customerService;
			_mapper = mapper;
		}
		public IActionResult Index()
		{
			return View();
		}

		//Listing Only Active Customers
		[Route("[controller]/ListActive")]
		public async Task<IActionResult> GetAllActiveCustomers()
		{
			var customerListDTO = await _customerService.GetDefaults(x => x.Status == Domain.Enums.Status.Active);
			var customerListVM = _mapper.Map<List<CustomerListVM>>(customerListDTO);
			return View(customerListVM);
		}

        //Listing All Customers
        [Route("[controller]/List")]
        public async Task<IActionResult> GetAllCustomers()
		{
			List<CustomerListVM> customerList = _mapper.Map<List<CustomerListVM>>(await _customerService.All());
			return View(customerList);
		}

		//Adding Customers
		[HttpGet]
		public IActionResult Create()
		{
			CustomerCreateVM customerCreateVm = new CustomerCreateVM();

			return View(customerCreateVm);

		}

		[HttpPost]
		public async Task<IActionResult> Create(CustomerCreateVM customerCreateVm)
		{
			if (ModelState.IsValid)
			{
				try
				{
					var customerCreateDto = _mapper.Map<CustomerCreateDTO>(customerCreateVm);
					await _customerService.Create(customerCreateDto);
					return RedirectToAction("GetAllCustomers");
				}
				catch (Exception ex)
				{
					TempData["error"] = ex.Message;
				}
			}
			return View(customerCreateVm);
		}

		//Delete Customer
		public async Task<IActionResult> Delete(int id,bool active)
		{
			try
			{
				await _customerService.Delete(id);
			}
			catch (Exception ex)
			{
				TempData["error"] = ex.Message;
			}
            if (active)
            {
                return RedirectToAction("GetAllActiveCustomers");
            }
            return RedirectToAction("GetAllCustomers");
        }

		//Update Model
		[HttpGet]
		public async Task<IActionResult> UpdateDetails(int id)
		{
			if (await _customerService.GetById(id) == null)
			{
				return NotFound();
			}
			else
			{
				CustomerUpdateVM customerUpdateVm = _mapper.Map<CustomerUpdateVM>(await _customerService.GetById(id));
				return View(customerUpdateVm);
			}
		}

		[HttpPost]
		public async Task<IActionResult> UpdateDetails(CustomerUpdateVM customerUpdateVm)
		{

			var customerUpdateDto = _mapper.Map<CustomerUpdateDTO>(customerUpdateVm);
			await _customerService.Update(customerUpdateDto);
			return RedirectToAction("GetAllActiveCustomers");
		}

        public async Task<IActionResult> Details(int id)
        {
            if (await _customerService.GetById(id) == null)
            {
                return NotFound();
            }
            else
            {
                CustomerVM customerVM = _mapper.Map<CustomerVM>(await _customerService.GetById(id));

                return View(customerVM);
            }
        }
    }
}
