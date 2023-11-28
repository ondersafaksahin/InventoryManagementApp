using AutoMapper;
using InventoryManagementApp.Application.DTOs.SalesOrdesDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.SalesOrderService
{
    public class SalesOrderService : ISalesOrderService
    {
        ISalesOrderRepository _salesOrderRepository;
        IMapper _mapper;

        public SalesOrderService(ISalesOrderRepository salesOrderRepository, IMapper mapper)
        {
            _salesOrderRepository = salesOrderRepository;
            _mapper = mapper;
        }
        public async Task<List<SalesOrderListDTO>> All()
        {
            return _mapper.Map<List<SalesOrderListDTO>>(await _salesOrderRepository.GetAll());
        }

        public async Task<int> Create(SalesOrderCreateDTO createDTO)
        {
            var salesOrder = _mapper.Map<SalesOrder>(createDTO);
            await _salesOrderRepository.Add(salesOrder);
            return salesOrder.ID;
        }

        public async Task Delete(int id)
        {
            await _salesOrderRepository.Delete(await _salesOrderRepository.GetById(x => x.ID == id));
        }

        public async Task<SalesOrderDTO> GetById(int id)
        {
            var salesOrder = await _salesOrderRepository.GetById(x => x.ID == id);
            return _mapper.Map<SalesOrderDTO>(salesOrder);
        }

        public async Task<List<SalesOrderListDTO>> GetDefaults(Expression<Func<SalesOrder, bool>> expression)
        {
            return _mapper.Map<List<SalesOrderListDTO>>(await _salesOrderRepository.GetDefaults(expression));
        }

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(SalesOrderUpdateDTO updateDTO)
        {
            await _salesOrderRepository.Update(_mapper.Map<SalesOrder>(updateDTO));
        }
    }
}
