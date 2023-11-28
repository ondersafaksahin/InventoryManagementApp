using AutoMapper;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDTOs;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.PurchaseOrderService
{
    public class PurchaseOrderService : IPurchaseOrderService
    {

        IPurchaseOrderRepository _purchaseOrderRepository;
        IMapper _mapper;

        public PurchaseOrderService(IPurchaseOrderRepository purchaseOrderRepository, IMapper mapper)
        {
            _purchaseOrderRepository = purchaseOrderRepository;
            _mapper = mapper;
        }

        public async Task<List<PurchaseOrderListDTO>> All()
        {
            return _mapper.Map<List<PurchaseOrderListDTO>>(await _purchaseOrderRepository.GetAll());
        }

        public async Task<int> Create(PurchaseOrderCreateDTO createDTO)
        {
           var purchaseOrder= _mapper.Map<PurchaseOrder>(createDTO);
           await _purchaseOrderRepository.Add(purchaseOrder);
            return purchaseOrder.ID;

        }

        public async Task Delete(int id)
        {
            await _purchaseOrderRepository.Delete(await _purchaseOrderRepository.GetById(x => x.ID == id));
        }

        public async Task<PurchaseOrderDTO> GetById(int id)
        {
            var purchaseOrder = await _purchaseOrderRepository.GetById(x => x.ID == id);
            return _mapper.Map<PurchaseOrderDTO>(purchaseOrder);
        }

        public async Task<List<PurchaseOrderListDTO>> GetDefaults(Expression<Func<PurchaseOrder, bool>> expression)
        {
            return _mapper.Map<List<PurchaseOrderListDTO>>(await _purchaseOrderRepository.GetDefaults(expression));
        }

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(PurchaseOrderUpdateDTO updateDTO)
        {
            await _purchaseOrderRepository.Update(_mapper.Map<PurchaseOrder>(updateDTO));
        }
    }
}
