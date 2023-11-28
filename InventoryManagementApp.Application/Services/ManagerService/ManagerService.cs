using AutoMapper;
using InventoryManagementApp.Application.DTOs.ManagerDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.ManagerService
{
    public class ManagerService : IManagerService
    {
        private readonly IManagerRepository _managerRepository;
        private readonly IMapper _mapper;

        public ManagerService(IManagerRepository managerRepository, IMapper mapper)
        {
            _managerRepository = managerRepository;
            _mapper = mapper;
        }

        public async Task<List<ManagerListDTO>> All()
        {
            return _mapper.Map<List<ManagerListDTO>>(await _managerRepository.GetAll());
        }

        public async Task<Guid> Create(ManagerCreateDTO createDTO)
        {
            var manager = _mapper.Map<Manager>(createDTO);
            await _managerRepository.Add(manager);
            return manager.Id;
        }

        public async Task Delete(Guid id)
        {
            await _managerRepository.Delete(await _managerRepository.GetById(x => x.Id == id));
        }

        public async Task<ManagerDTO> GetById(Guid id)
        {
            return _mapper.Map<ManagerDTO>(await _managerRepository.GetById(x => x.Id == id));
        }

        public async Task<List<ManagerListDTO>> GetDefaults(Expression<Func<Manager, bool>> expression)
        {
            return _mapper.Map<List<ManagerListDTO>>(await _managerRepository.GetDefaults(expression));
        }

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(ManagerUpdateDTO updateDTO)
        {
            await _managerRepository.Update(_mapper.Map<Manager>(updateDTO));
        }
    }
}
