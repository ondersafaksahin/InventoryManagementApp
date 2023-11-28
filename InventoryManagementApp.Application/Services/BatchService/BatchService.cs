using AutoMapper;
using InventoryManagementApp.Application.DTOs.BatchDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.BatchService
{
    public class BatchService : IBatchService
    {
        IBatchRepository _batchRepository;
        IMapper _mapper;
        public BatchService(IBatchRepository batchRepository, IMapper mapper)
        {
            _batchRepository = batchRepository;
            _mapper = mapper;
        }
        public async Task<List<BatchListDTO>> All()
        {
            return _mapper.Map<List<BatchListDTO>>(await _batchRepository.GetAll());
        }

        public async Task<int> Create(BatchCreateDTO createDTO)
        {
            var batch = _mapper.Map<Batch>(createDTO);
            await _batchRepository.Add(batch);
            return batch.ID;
        }

        public async Task Delete(int id)
        {
            await _batchRepository.Delete(await _batchRepository.GetById(x => x.ID == id));
        }

        public async Task<BatchDTO> GetById(int id)
        {
            return _mapper.Map<BatchDTO>(await _batchRepository.GetById(x => x.ID == id));
        }

        public async Task<List<BatchListDTO>> GetDefaults(Expression<Func<Batch, bool>> expression)
        {
            return _mapper.Map<List<BatchListDTO>>(await _batchRepository.GetDefaults(expression));
        }

        public async Task<string?> GetNameById(int? Id)
        {
            var batch = await _batchRepository.GetById(x => x.ID == Id);
            return batch?.BatchCode;
        }

        public async Task Update(BatchUpdateDTO updateDTO)
        {
            await _batchRepository.Update(_mapper.Map<Batch>(updateDTO));
        }
    }
}
