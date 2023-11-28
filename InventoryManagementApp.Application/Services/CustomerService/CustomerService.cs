using AutoMapper;
using InventoryManagementApp.Application.DTOs.CustomerDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.CustomerService
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;
        IMapper _mapper;
        public CustomerService(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }
        public async Task<List<CustomerListDTO>> All()
        {
            return _mapper.Map<List<CustomerListDTO>>(await _customerRepository.GetAll());
        }

        public async Task<int> Create(CustomerCreateDTO createDTO)
        {
            var customer = _mapper.Map<Customer>(createDTO);
            await _customerRepository.Add(customer);
            return customer.ID;
        }

        public async Task Delete(int id)
        {
            await _customerRepository.Delete(await _customerRepository.GetById(x => x.ID == id));
        }

        public async Task<CustomerDTO> GetById(int id)
        {
            return _mapper.Map<CustomerDTO>(await _customerRepository.GetById(x => x.ID == id));
        }

        public async Task<List<CustomerListDTO>> GetDefaults(Expression<Func<Customer, bool>> expression)
        {
            return _mapper.Map<List<CustomerListDTO>>(await _customerRepository.GetDefaults(expression));
        }

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(CustomerUpdateDTO updateDTO)
        {
            await _customerRepository.Update(_mapper.Map<Customer>(updateDTO));
        }
    }
}
