using AutoMapper;
using InventoryManagementApp.Application.DTOs.BatchDTOs;
using InventoryManagementApp.Application.DTOs.DeliveryDetailDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.DeliveryDetailService
{
    public class DeliveryDetailService : IDeliveryDetailService
    {
        IDeliveryDetailRepository _deliveryDetailRepository;
        IMapper _mapper;
        public DeliveryDetailService(IDeliveryDetailRepository deliveryDetailRepository, IMapper mapper)
        {
            _deliveryDetailRepository = deliveryDetailRepository;
            _mapper = mapper;
        }

        public async Task<List<DeliveryDetailListDTO>> All()
        {

            return _mapper.Map<List<DeliveryDetailListDTO>>(await _deliveryDetailRepository.GetAll());
        }

        public async Task<int> Create(DeliveryDetailDTO createDTO)
        {
            var deliveryDetail = _mapper.Map<DeliveryDetail>(createDTO);
            await _deliveryDetailRepository.Add(deliveryDetail);
            return deliveryDetail.ID;
        }

        public async Task Delete(int id)
        {
            await _deliveryDetailRepository.Delete(await _deliveryDetailRepository.GetById(x => x.ID == id));
        }

        public async Task<DeliveryDetailDTO> GetById(int id)
        {
            return _mapper.Map<DeliveryDetailDTO>(await _deliveryDetailRepository.GetById(x => x.ID == id));
        }

        public async Task<List<DeliveryDetailListDTO>> GetDefaults(Expression<Func<DeliveryDetail, bool>> expression)
        {
            return _mapper.Map<List<DeliveryDetailListDTO>>(await _deliveryDetailRepository.GetDefaults(expression));
        }

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(DeliveryDetailUpdateDTO updateDTO)
        {
            await _deliveryDetailRepository.Update(_mapper.Map<DeliveryDetail>(updateDTO));
        }


    }
}
