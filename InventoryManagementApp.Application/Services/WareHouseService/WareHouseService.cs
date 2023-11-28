using AutoMapper;
using InventoryManagementApp.Application.DTOs.PurchaseOrderDTOs;
using InventoryManagementApp.Application.DTOs.WareHouseDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.WareHouseService
{
    public class WareHouseService : IWareHouseService
    {
        IWareHouseRepository _wareHouseRepository;
        IMapper _mapper;

        public WareHouseService(IWareHouseRepository wareHouseRepository, IMapper mapper)
        {
            _wareHouseRepository = wareHouseRepository;
            _mapper = mapper;
        }
        public async Task<List<WareHouseListDTO>> All()
        {
            return _mapper.Map<List<WareHouseListDTO>>(await _wareHouseRepository.GetAll());
        }

        public async Task<int> Create(WareHouseCreateDTO createDTO)
        {
            var wareHouse = _mapper.Map<Warehouse>(createDTO);
            await _wareHouseRepository.Add(wareHouse);
            return wareHouse.ID;
        }

        public async Task Delete(int id)
        {
            await _wareHouseRepository.Delete(await _wareHouseRepository.GetById(x => x.ID == id));
        }

        public async Task<WareHouseDTO> GetById(int id)
        {
            var wareHouse = await _wareHouseRepository.GetById(x => x.ID == id);
            return _mapper.Map<WareHouseDTO>(wareHouse);
        }

        public async Task<List<WareHouseListDTO>> GetDefaults(Expression<Func<Warehouse, bool>> expression)
        {
            return _mapper.Map<List<WareHouseListDTO>>(await _wareHouseRepository.GetDefaults(expression));
        }

        public async Task Update(WareHouseUpdateDTO updateDTO)
        {
            await _wareHouseRepository.Update(_mapper.Map<Warehouse>(updateDTO));
        }

        public async Task<string?> GetNameById(int? Id)
        {
            var warehouse = await _wareHouseRepository.GetById(x => x.ID == Id);
            return warehouse?.Name;
        }
    }
}
