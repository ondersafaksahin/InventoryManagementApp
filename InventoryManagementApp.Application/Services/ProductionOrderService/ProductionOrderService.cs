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

		public async Task<int> Create(ProductionOrderCreateDTO createDTO)
		{
			var productionOrder = _mapper.Map<ProductionOrder>(createDTO);
            await _productionOrderRepository.Add(productionOrder);
			return productionOrder.ID;
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

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(ProductionOrderUpdateDTO updateDTO)
		{
            var prodOrder = await GetById(updateDTO.ID);
            var updatedprodOrder = _mapper.Map(updateDTO, prodOrder);
            await _productionOrderRepository.Update(_mapper.Map<ProductionOrder>(updatedprodOrder));
        }
	}
}
