using AutoMapper;
using InventoryManagementApp.Application.DTOs.SupplierDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.SupplierService
{
	public class SupplierService : ISupplierService
	{
		ISupplierRepository _supplierRepository;
		IMapper _mapper;
        public SupplierService(IMapper mapper, ISupplierRepository supplierRepository)
        {
			_mapper = mapper;
			_supplierRepository = supplierRepository;

		}
        public async Task<List<SupplierListDTO>> All()
		{
			return _mapper.Map<List<SupplierListDTO>>(await _supplierRepository.GetAll());
		}

		public async Task Create(SupplierCreateDTO createDTO)
		{
			await _supplierRepository.Add(_mapper.Map<Supplier>(createDTO));
		}

		public async Task Delete(int id)
		{
			await _supplierRepository.Delete(await _supplierRepository.GetById(x=>x.ID==id));
		}

		public async Task<SupplierDTO> GetById(int id)
		{
			return _mapper.Map<SupplierDTO>(await _supplierRepository.GetById(x => x.ID == id));
		}

		public async Task<List<SupplierListDTO>> GetDefaults(Expression<Func<Supplier, bool>> expression)
		{
			return _mapper.Map<List<SupplierListDTO>>(await _supplierRepository.GetDefaults(expression));
		}

		public async Task Update(SupplierUpdateDTO updateDTO)
		{
			await _supplierRepository.Update(_mapper.Map<Supplier>(updateDTO));
		}
	}
}
