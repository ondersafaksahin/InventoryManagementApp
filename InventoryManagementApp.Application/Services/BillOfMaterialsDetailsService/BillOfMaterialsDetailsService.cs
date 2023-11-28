using AutoMapper;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDetailsDTOs;
using InventoryManagementApp.Application.DTOs.ProductionOrderDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.BillOfMaterialsDetailsService
{
	public class BillOfMaterialsDetailsService : IBillOfMaterialsDetailsService
	{
		IBillOfMaterialDetailsRepository _bomDetailsRepository;
		IMapper _mapper;

		public BillOfMaterialsDetailsService(IBillOfMaterialDetailsRepository bomDetailsRepository, IMapper mapper)
		{
			_bomDetailsRepository = bomDetailsRepository;
			_mapper = mapper;
		}


		public async Task<List<BillOfMaterialsDetailsListDTO>> All()
		{
			return _mapper.Map<List<BillOfMaterialsDetailsListDTO>>(await _bomDetailsRepository.GetAll());
		}

		public async Task<int> Create(BillOfMaterialsDetailsCreateDTO createDTO)
		{
			var bom = _mapper.Map<BillOfMaterialDetails>(createDTO);
            await _bomDetailsRepository.Add(bom);
			return bom.ID;
		}

		public async Task Delete(int id)
		{
			var BillOfMaterialsDetails = await _bomDetailsRepository.GetById(x => x.ID == id);
			await _bomDetailsRepository.Delete(BillOfMaterialsDetails);
		}

		public async Task<BillOfMaterialsDetailsDTO> GetById(int id)
		{
			return _mapper.Map<BillOfMaterialsDetailsDTO>(await _bomDetailsRepository.GetById(x => x.ID == id));
		}

		public async Task<List<BillOfMaterialsDetailsListDTO>> GetDefaults(Expression<Func<BillOfMaterialDetails, bool>> expression)
		{
			return _mapper.Map<List<BillOfMaterialsDetailsListDTO>>(await _bomDetailsRepository.GetDefaults(expression));
		}

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(BillOfMaterialsDetailsUpdateDTO updateDTO)
		{
			await _bomDetailsRepository.Update(_mapper.Map<BillOfMaterialDetails>(updateDTO));
		}
	}
}
