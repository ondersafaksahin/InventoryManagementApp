using AutoMapper;
using AutoMapper.Configuration;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDetailDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.PurchaseOrderDetailService
{
    public class PurchaseOrderDetailService : IPurchaseOrderDetailService
    {
        IPurchaseOrderDetailsRepository _purchaseOrderDetailsRepository;
        IMapper _mapper;

        public PurchaseOrderDetailService(IPurchaseOrderDetailsRepository purchaseOrderDetailsRepository, IMapper mapper)
        {
            _purchaseOrderDetailsRepository = purchaseOrderDetailsRepository;
            _mapper = mapper;
        }

        public async Task<List<PurchaseOrderDetailListDTO>> All()
        {
            return _mapper.Map<List<PurchaseOrderDetailListDTO>>(await _purchaseOrderDetailsRepository.GetAll());
        }

        public async Task<int> Create(PurchaseOrderDetailCreateDTO createDTO)
        {
            var purchaseOrderDetail = _mapper.Map<PurchaseOrderDetails>(createDTO);
            await _purchaseOrderDetailsRepository.Add(purchaseOrderDetail);
            return purchaseOrderDetail.ID;
        }

        public async Task Delete(int id)
        {
            await _purchaseOrderDetailsRepository.Delete(await _purchaseOrderDetailsRepository.GetById(x => x.ID == id));
        }

        public async Task<PurchaseOrderDetailDTO> GetById(int id)
        {
            return _mapper.Map<PurchaseOrderDetailDTO>(await _purchaseOrderDetailsRepository.GetById(x => x.ID == id));
        }

        public async Task<List<PurchaseOrderDetailListDTO>> GetDefaults(Expression<Func<PurchaseOrderDetails, bool>> expression)
        {
            return _mapper.Map<List<PurchaseOrderDetailListDTO>>(await _purchaseOrderDetailsRepository.GetDefaults(expression));
        }

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(PurchaseOrderDetailUpdateDTO updateDTO)
        {
            await _purchaseOrderDetailsRepository.Update(_mapper.Map<PurchaseOrderDetails>(updateDTO));
        }
    }
}
