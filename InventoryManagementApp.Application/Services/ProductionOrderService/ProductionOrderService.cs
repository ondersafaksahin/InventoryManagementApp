using AutoMapper;
using InventoryManagementApp.Application.DTOs.ProductionOrderDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.ProductionOrderService
{
	public class ProductionOrderService : IProductionOrderService
	{
		IProductionOrderRepository _productionOrderRepository;
		IMapper _mapper;

		public ProductionOrderService(IProductionOrderRepository productionOrderRepository, IMapper mapper)
		{
			_productionOrderRepository = productionOrderRepository;
			_mapper = mapper;
		}


		public async Task<List<ProductionOrderListDTO>> All()
		{
			return _mapper.Map<List<ProductionOrderListDTO>>(await _productionOrderRepository.GetAll());
		}

		public async Task Create(ProductionOrderCreateDTO createDTO)
		{
			await _productionOrderRepository.Add(_mapper.Map<ProductionOrder>(createDTO));
		}

		public async Task Delete(int id)
		{
			var productionOrder = await _productionOrderRepository.GetById(x=>x.ID==id);
			await _productionOrderRepository.Delete(productionOrder);
		}

		public async Task<ProductionOrderDTO> GetById(int id)
		{
			return _mapper.Map<ProductionOrderDTO>(await _productionOrderRepository.GetById(x => x.ID == id));
		}

		public async Task<List<ProductionOrderListDTO>> GetDefaults(Expression<Func<ProductionOrder, bool>> expression)
		{
			return _mapper.Map<List<ProductionOrderListDTO>>(await _productionOrderRepository.GetDefaults(expression));
		}

		public async Task Update(ProductionOrderUpdateDTO updateDTO)
		{
			await _productionOrderRepository.Update(_mapper.Map<ProductionOrder>(updateDTO));
		}
	}
}
