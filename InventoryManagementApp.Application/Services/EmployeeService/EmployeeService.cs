using AutoMapper;
using InventoryManagementApp.Application.DTOs.EmployeeDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeListDTO>> All()
        {
            return _mapper.Map<List<EmployeeListDTO>>(await _employeeRepository.GetAll());
        }

        public async Task<Guid> Create(EmployeeCreateDTO createDTO)
        {
            var employee = _mapper.Map<Employee>(createDTO);
            await _employeeRepository.Add(employee);
            return employee.Id;
        }

        public async Task Delete(Guid id)
        {
            await _employeeRepository.Delete(await _employeeRepository.GetById(x => x.Id == id));
        }

        public async Task<EmployeeDTO> GetById(Guid id)
        {
            return _mapper.Map<EmployeeDTO>(await _employeeRepository.GetById(x => x.Id == id));
        }

        public async Task<List<EmployeeListDTO>> GetDefaults(Expression<Func<Employee, bool>> expression)
        {
            return _mapper.Map<List<EmployeeListDTO>>(await _employeeRepository.GetDefaults(expression));
        }

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(EmployeeUpdateDTO updateDTO)
        {
            await _employeeRepository.Update(_mapper.Map<Employee>(updateDTO));
        }
    }
}
