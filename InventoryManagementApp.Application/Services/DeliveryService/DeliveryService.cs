using AutoMapper;
using InventoryManagementApp.Application.DTOs.BatchDTOs;
using InventoryManagementApp.Application.DTOs.DeliveryDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.DeliveryService
{
    public class DeliveryService : IDeliveryService
    {
        IDeliveryRepository _deliveryRepository;
        IMapper _mapper;
        public DeliveryService(IDeliveryRepository deliveryRepository, IMapper mapper)
        {
            _deliveryRepository = deliveryRepository;
            _mapper = mapper;
        }
        public async Task<List<DeliveryListDTO>> All()
        {
            return _mapper.Map<List<DeliveryListDTO>>(await _deliveryRepository.GetAll());
        }

        public async Task<int> Create(DeliveryCreateDTO createDTO)
        {
            var delivery = _mapper.Map<Delivery>(createDTO);
            await _deliveryRepository.Add(delivery);
            return delivery.ID;
        }

        public async Task Delete(int id)
        {
            await _deliveryRepository.Delete(await _deliveryRepository.GetById(x => x.ID == id));
        }

        public async Task<DeliveryDTO> GetById(int id)
        {
            return _mapper.Map<DeliveryDTO>(await _deliveryRepository.GetById(x => x.ID == id));
        }

        public async Task<List<DeliveryListDTO>> GetDefaults(Expression<Func<Delivery, bool>> expression)
        {
            return _mapper.Map<List<DeliveryListDTO>>(await _deliveryRepository.GetDefaults(expression));
        }

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(DeliveryUpdateDTO updateDTO)
        {
            await _deliveryRepository.Update(_mapper.Map<Delivery>(updateDTO));
        }
    }
}
