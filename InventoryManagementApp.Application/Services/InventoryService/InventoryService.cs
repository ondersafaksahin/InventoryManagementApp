using AutoMapper;
using InventoryManagementApp.Application.DTOs.InventoryDTOs;
using InventoryManagementApp.Application.DTOs.SubCategoryDTOs;
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
        IGoodRepository _goodRepository;
        IWareHouseRepository _wareHouseRepository;
        IMapper _mapper;
        public InventoryService(IInventoryRepository inventoryRepository, IMapper mapper, IGoodRepository goodRepository, IWareHouseRepository wareHouseRepository)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
            _goodRepository = goodRepository;
            _wareHouseRepository = wareHouseRepository;
        }

        public async Task<List<InventoryListDTO>> All()
        {
            var list = _mapper.Map<List<InventoryListDTO>>(await _inventoryRepository.GetAll());

            foreach (var item in list)
            {
                var good = _goodRepository.GetById(x => x.ID == item.GoodId);
                item.Good = good.Result;
                
            }
            foreach (var item in list)
            {
                if (item.WarehouseId != null)
                {
                    var warehouse = _wareHouseRepository.GetById(x => x.ID == item.WarehouseId);
                    item.Warehouse = warehouse.Result;
                }
                else
                {
                    item.Warehouse = null;
                }
            }
           
            return list;
        }

        public async Task<int> Create(InventoryCreateDTO createDTO)
        {
            var inventory = await FindExistingInventory(createDTO);
            if (inventory is null)
            {
                var newInventory = _mapper.Map<Inventory>(createDTO);
                await _inventoryRepository.Add(newInventory);
                return newInventory.ID;
            }
            else
            {
                inventory.Amount += createDTO.Amount;
                var invupdateDTO = _mapper.Map<InventoryUpdateDTO>(inventory);
                await Update(invupdateDTO);
                return inventory.ID;
            }
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
            var list = _mapper.Map<List<InventoryListDTO>>(await _inventoryRepository.GetDefaults(expression));

            foreach (var item in list)
            {
                var good = _goodRepository.GetById(x => x.ID == item.GoodId);
                item.Good = good.Result;

            }
            foreach (var item in list)
            {
                if (item.WarehouseId != null)
                {
                    var warehouse = _wareHouseRepository.GetById(x => x.ID == item.WarehouseId);
                    item.Warehouse = warehouse.Result;
                }
                else
                {
                    item.Warehouse = null;
                }
            }


            return list;
        }

        public async Task Update(InventoryUpdateDTO updateDTO)
        {
            var inventory = await GetById(updateDTO.ID);
            var updatedInventory = _mapper.Map(updateDTO, inventory);
            await _inventoryRepository.Update(_mapper.Map<Inventory>(updatedInventory));
        }

        private async Task<Inventory?> FindExistingInventory(InventoryCreateDTO inventoryCreateDTO)
        {
            var inventory = (await _inventoryRepository.GetAll()).FirstOrDefault(x => x.WarehouseId == inventoryCreateDTO.WarehouseId && x.GoodId == inventoryCreateDTO.GoodId && x.BatchId == inventoryCreateDTO.BatchId);
            return inventory;
        }
    }
}
