using AutoMapper;
using InventoryManagementApp.Application.DTOs.BatchDTOs;
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
        private readonly IGoodRepository _goodRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IBatchRepository _batchRepository;
        private readonly IMapper _mapper;

        public GoodService(IGoodRepository goodRepository, IMapper mapper, IInventoryRepository inventoryRepository, IBatchRepository batchRepository)
        {
            _goodRepository = goodRepository;
            _mapper = mapper;
            _inventoryRepository = inventoryRepository;
            _batchRepository = batchRepository;
        }

        public async Task<List<GoodListDTO>> All()
        {
            return _mapper.Map<List<GoodListDTO>>(await _goodRepository.GetAll());
        }

        public async Task<int> Create(GoodCreateDTO createDTO)
        {
            var good = _mapper.Map<Good>(createDTO);
            await _goodRepository.Add(good);
            return good.ID;
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
            var list = _mapper.Map<List<GoodListDTO>>(await _goodRepository.GetDefaults(expression));
            return list;
        }

        public async Task<string?> GetNameById(int? Id)
        {
            var good = await _goodRepository.GetById(x => x.ID == Id);
            return good?.Name;
        }

        public async Task<string?> GetCodeById(int? Id)
        {
            var good = await _goodRepository.GetById(x => x.ID == Id);
            return good?.Code;
        }

        public async Task Update(GoodUpdateDTO updateDTO)
        {
            var good = await GetById(updateDTO.ID);
            var updatedGood = _mapper.Map(updateDTO, good);
            await _goodRepository.Update(_mapper.Map<Good>(updatedGood));
        }

        public async Task<Dictionary<int,string>> GetGoodBatches(int goodId)
        {
            var inventories = (await _inventoryRepository.GetDefaults(x => x.GoodId == goodId)).DistinctBy(x => x.BatchId); 
            var batches = new Dictionary<int, string>();
            foreach (var item in inventories)
            {
                if (item.BatchId is not null)
                {
                    batches.Add((int)item.BatchId, (await _batchRepository.GetById(x => x.ID == item.BatchId)).BatchCode);
                }
            }
            return batches;
        }
    }
}
