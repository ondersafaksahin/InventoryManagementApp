using AutoMapper;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDTOs;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.GoodService
{
    public class GoodService : IGoodService
    {
        IGoodRepository _goodRepository;
        IMapper _mapper;

        public GoodService(IGoodRepository goodRepository, IMapper mapper)
        {
            _goodRepository = goodRepository;
            _mapper = mapper;
        }

        public async Task<List<GoodListDTO>> All()
        {
            return _mapper.Map<List<GoodListDTO>>(await _goodRepository.GetAll());
        }

        public async Task Create(GoodCreateDTO createDTO)
        {
  
            var good = _mapper.Map<Good>(createDTO);
            await _goodRepository.Add(good);
        }

        public async Task Delete(int id)
        {
            await _goodRepository.Delete(await _goodRepository.GetById(x => x.ID == id));
         
        }

        public async Task<GoodDTO> GetById(int id)
        {
           return _mapper.Map<GoodDTO>(await _goodRepository.GetById(x => x.ID == id));
        }

        public async Task<List<GoodListDTO>> GetDefaults(Expression<Func<Good, bool>> expression)
        {
            return _mapper.Map<List<GoodListDTO>>(await _goodRepository.GetDefaults(expression));
        }

        public async Task Update(GoodUpdateDTO updateDTO)
        {
            await _goodRepository.Update(_mapper.Map<Good>(updateDTO));
        }
    }
}
