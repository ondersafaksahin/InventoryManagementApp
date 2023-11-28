using AutoMapper;
using InventoryManagementApp.Application.DTOs.ConversionDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.ConversionService
{
	public class ConversionService : IConversionService
	{
		IConversionRepository _conversionRepository;
		IGoodRepository _goodRepository;
		IMapper _mapper;

		public ConversionService(IConversionRepository conversionRepository, IMapper mapper, IGoodRepository goodRepository)
		{
			_conversionRepository = conversionRepository;
			_mapper = mapper;
			_goodRepository = goodRepository;
		}


		public async Task<List<ConversionListDTO>> All()
		{
			return _mapper.Map<List<ConversionListDTO>>(await _conversionRepository.GetAll());
		}

		public async Task<int> Create(ConversionCreateDTO createDTO)
		{
			var conversion = _mapper.Map<Conversion>(createDTO);
            await _conversionRepository.Add(conversion);
			return conversion.ID;
		}

		public async Task Delete(int id)
		{
			var Conversion = await _conversionRepository.GetById(x => x.ID == id);
			await _conversionRepository.Delete(Conversion);
		}

		public async Task<ConversionDTO> GetById(int id)
		{
			return _mapper.Map<ConversionDTO>(await _conversionRepository.GetById(x => x.ID == id));
		}

		public async Task<List<ConversionListDTO>> GetDefaults(Expression<Func<Conversion, bool>> expression)
		{
			return _mapper.Map<List<ConversionListDTO>>(await _conversionRepository.GetDefaults(expression));
		}

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(ConversionUpdateDTO updateDTO)
		{
			var conversion = await GetById(updateDTO.ID);
			var updatedConversion = _mapper.Map(updateDTO, conversion);
			await _conversionRepository.Update(_mapper.Map<Conversion>(updatedConversion));
		}
	}
}
