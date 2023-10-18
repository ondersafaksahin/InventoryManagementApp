using AutoMapper;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDTOs;
using InventoryManagementApp.Application.DTOs.ShelfDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.ShelfService
{
    public class ShelfService : IShelfService
    {
        IShelfRepository _shelfRepository;
        IWareHouseRepository _wareHouseRepository;  
        IMapper _mapper;

        public ShelfService(IShelfRepository shelfRepository, IMapper mapper, IWareHouseRepository wareHouseRepository)
        {
            _shelfRepository = shelfRepository;
            _wareHouseRepository = wareHouseRepository;
            _mapper = mapper;
        }
        public async Task<List<ShelfListDTO>> All()
        {
            return _mapper.Map<List<ShelfListDTO>>(await _shelfRepository.GetAll());
        }

        public async Task Create(ShelfCreateDTO createDTO)
        {
            var shelf = _mapper.Map<Shelf>(createDTO);
            await _shelfRepository.Add(shelf);
        }

        public async Task Delete(int id)
        {
            await _shelfRepository.Delete(await _shelfRepository.GetById(x => x.ID == id));
        }




        public async Task<ShelfDTO> GetById(int id)
        {
            var shelf = await _shelfRepository.GetById(x => x.ID == id);

            return _mapper.Map<ShelfDTO>(shelf);
        }



        public async Task<List<ShelfListDTO>> GetDefaults(Expression<Func<Shelf, bool>> expression)
        { 
            var list = _mapper.Map<List<ShelfListDTO>>(await _shelfRepository.GetDefaults(expression));
            var warehouse =await _wareHouseRepository.GetAll();

            foreach (var item in list)
            {
                foreach (var wh in warehouse)
                {
                    if(wh.ID == item.WarehouseID)
                    {
                        item.Warehouse = wh;
                    }
                }
            }
        
            return list;

        }

        public async Task Update(ShelfUpdateDTO updateDTO)
        {
            await _shelfRepository.Update(_mapper.Map<Shelf>(updateDTO));
        }

    }
}
