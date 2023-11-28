using AutoMapper;
using InventoryManagementApp.Application.DTOs.ConsumptionDTOs;
using InventoryManagementApp.Application.DTOs.ConversionDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.ConsumpitonService
{
	public class ConsumptionService:IConsumptionService
	{
		IConsumptionRepository _consumptionRepository;
		IMapper _mapper;

		public ConsumptionService(IConsumptionRepository consumptionRepository, IMapper mapper)
		{
			_consumptionRepository = consumptionRepository;
			_mapper = mapper;
		}


		public async Task<List<ConsumptionListDTO>> All()
		{
			return _mapper.Map<List<ConsumptionListDTO>>(await _consumptionRepository.GetAll());
		}

		public async Task<int> Create(ConsumptionCreateDTO createDTO)
		{
			var consumption = _mapper.Map<Consumption>(createDTO);
            await _consumptionRepository.Add(consumption);
			return consumption.ID;
		}

		public async Task Delete(int id)
		{
			var Consumption = await _consumptionRepository.GetById(x => x.ID == id);
			await _consumptionRepository.Delete(Consumption);
		}

		public async Task<ConsumptionDTO> GetById(int id)
		{
			return _mapper.Map<ConsumptionDTO>(await _consumptionRepository.GetById(x => x.ID == id));
		}

		public async Task<List<ConsumptionListDTO>> GetDefaults(Expression<Func<Consumption, bool>> expression)
		{
			return _mapper.Map<List<ConsumptionListDTO>>(await _consumptionRepository.GetDefaults(expression));
		}

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(ConsumptionUpdateDTO updateDTO)
		{
			await _consumptionRepository.Update(_mapper.Map<Consumption>(updateDTO));
		}
	}
}