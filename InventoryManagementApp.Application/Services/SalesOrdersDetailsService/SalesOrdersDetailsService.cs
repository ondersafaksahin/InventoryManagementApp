using AutoMapper;
using InventoryManagementApp.Application.DTOs.SalesOrdesDetailsDTOs;
using InventoryManagementApp.Application.DTOs.SalesOrdesDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.SalesOrdersDetailsService
{
    public class SalesOrdersDetailsService:ISalesOrdersDetailsService
    {
        ISalesOrderDetailsRepository _salesOrderDetailsRepository;
        IMapper _mapper;

        public SalesOrdersDetailsService(ISalesOrderDetailsRepository salesOrderDetailsRepository, IMapper mapper)
        {
            _salesOrderDetailsRepository = salesOrderDetailsRepository;
            _mapper = mapper;
        }
        public async Task<List<SalesOrdersDetailsListDTO>> All()
        {
            return _mapper.Map<List<SalesOrdersDetailsListDTO>>(await _salesOrderDetailsRepository.GetAll());
        }

        public async Task<int> Create(SalesOrdersDetailsCreateDTO createDTO)
        {
            var salesOrderDetail = _mapper.Map<SalesOrderDetails>(createDTO);
            await _salesOrderDetailsRepository.Add(salesOrderDetail);
            return salesOrderDetail.ID;
        }

        public async Task Delete(int id)
        {
            await _salesOrderDetailsRepository.Delete(await _salesOrderDetailsRepository.GetById(x => x.ID == id));
        }

        public async Task<SalesOrdersDetailsDTO> GetById(int id)
        {
            var salesOrderDetail = await _salesOrderDetailsRepository.GetById(x => x.ID == id);
            return _mapper.Map<SalesOrdersDetailsDTO>(salesOrderDetail);
        }

        public async Task<List<SalesOrdersDetailsListDTO>> GetDefaults(Expression<Func<SalesOrderDetails, bool>> expression)
        {
            return _mapper.Map<List<SalesOrdersDetailsListDTO>>(await _salesOrderDetailsRepository.GetDefaults(expression));
        }

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(SalesOrdersDetailsUpdateDTO updateDTO)
        {
            await _salesOrderDetailsRepository.Update(_mapper.Map<SalesOrderDetails>(updateDTO));
        }
    }
}
