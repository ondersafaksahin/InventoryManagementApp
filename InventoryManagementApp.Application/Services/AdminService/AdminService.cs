using AutoMapper;
using InventoryManagementApp.Application.DTOs.AdminDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public AdminService(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }

        public async Task<List<AdminListDTO>> All()
        {
            return _mapper.Map<List<AdminListDTO>>(await _adminRepository.GetAll());
        }

        public async Task<Guid> Create(AdminCreateDTO createDTO)
        {
            var admin = _mapper.Map<Admin>(createDTO);
            await _adminRepository.Add(admin);
            return admin.Id;
        }

        public async Task Delete(Guid id)
        {
            await _adminRepository.Delete(await _adminRepository.GetById(x => x.Id == id));
        }

        public async Task<AdminDTO> GetById(Guid id)
        {
            return _mapper.Map<AdminDTO>(await _adminRepository.GetById(x => x.Id == id));
        }

        public async Task<List<AdminListDTO>> GetDefaults(Expression<Func<Admin, bool>> expression)
        {
            return _mapper.Map<List<AdminListDTO>>(await _adminRepository.GetDefaults(expression));
        }

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(AdminUpdateDTO updateDTO)
        {
            await _adminRepository.Update(_mapper.Map<Admin>(updateDTO));
        }
    }
}
