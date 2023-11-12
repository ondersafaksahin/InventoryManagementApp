using AutoMapper;
using InventoryManagementApp.Application.DTOs.InventoryDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.InventoryService
{
    public class InventoryService : IInventoryService
    {
        IInventoryRepository _inventoryRepository;
        IMapper _mapper;
        public InventoryService(IInventoryRepository inventoryRepository, IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        public async Task<List<InventoryListDTO>> All()
        {
            return _mapper.Map<List<InventoryListDTO>>(await _inventoryRepository.GetAll());
        }

        public async Task Create(InventoryCreateDTO createDTO)
        {
            var inventory = _mapper.Map<Inventory>(createDTO);
            await _inventoryRepository.Add(inventory);
        }

        public async Task Delete(int id)
        {
            var inventory = await _inventoryRepository.GetById(x => x.ID == id);
            await _inventoryRepository.Delete(inventory);
        }

        public async Task<InventoryDTO> GetById(int id)
        {
            return _mapper.Map<InventoryDTO>(await _inventoryRepository.GetById(x => x.ID == id));
        }

        public async Task<List<InventoryListDTO>> GetDefaults(Expression<Func<Inventory, bool>> expression)
        {
            return _mapper.Map<List<InventoryListDTO>>( await _inventoryRepository.GetDefaults(expression));
        }

        public async Task Update(InventoryUpdateDTO updateDTO)
        {
            var inventory = GetById(updateDTO.ID);
            var updatedInventory = _mapper.Map(updateDTO, inventory);
            await _inventoryRepository.Update(_mapper.Map<Inventory>(updatedInventory));
        }
    }
}
