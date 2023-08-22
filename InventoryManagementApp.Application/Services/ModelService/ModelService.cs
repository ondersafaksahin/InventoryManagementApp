using AutoMapper;
using InventoryManagementApp.Application.DTOs.ModelDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.ModelService
{
    public class ModelService : IModelService
    {
        IModelRepository _modelRepository;
        IMapper _mapper;
        public ModelService(IMapper mapper, IModelRepository modelRepository)
        {
            _mapper = mapper;
            _modelRepository = modelRepository;
        }
        public async Task<List<ModelListDTO>> All()
        {
            return _mapper.Map<List<ModelListDTO>>(await _modelRepository.GetAll());
        }

        public async Task Create(ModelCreateDTO createDTO)
        {
            await _modelRepository.Add(_mapper.Map<Model>(createDTO));
        }

        public async Task Delete(int id)
        {
            await _modelRepository.Delete(await _modelRepository.GetById(x => x.ID == id));
        }

        public async Task<ModelDTO> GetById(int id)
        {
            return _mapper.Map<ModelDTO>(await _modelRepository.GetById(x => x.ID == id));
        }

        public async Task<List<ModelListDTO>> GetDefaults(Expression<Func<Model, bool>> expression)
        {
            return _mapper.Map<List<ModelListDTO>>(await _modelRepository.GetDefaults(expression));
        }

        public async Task Update(ModelUpdateDTO updateDTO)
        {
            await _modelRepository.Update(_mapper.Map<Model>(updateDTO));
        }
    }
}
