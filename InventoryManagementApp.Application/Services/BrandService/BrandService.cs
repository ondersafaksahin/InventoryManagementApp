using AutoMapper;
using InventoryManagementApp.Application.DTOs.BrandDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.BrandService
{
    public class BrandService : IBrandService
    {
        IBrandRepository _brandRepository;
        IMapper _mapper;
        public BrandService(IBrandRepository brandRepository, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }
        public async Task<List<BrandListDTO>> All()
        {
            return _mapper.Map<List<BrandListDTO>>(await _brandRepository.GetAll());
        }

        public async Task<int> Create(BrandCreateDTO createDTO)
        {
            var brand = _mapper.Map<Brand>(createDTO);
            await _brandRepository.Add(brand);
            return brand.ID;
        }

        public async Task Delete(int id)
        {
            await _brandRepository.Delete(await _brandRepository.GetById(x => x.ID == id));
        }

        public async Task<BrandDTO> GetById(int id)
        {
            var brand = await _brandRepository.GetById(x => x.ID == id);
            return _mapper.Map<BrandDTO>(brand);
        }

        public async Task<List<BrandListDTO>> GetDefaults(Expression<Func<Brand, bool>> expression)
        {
            return _mapper.Map<List<BrandListDTO>>(await _brandRepository.GetDefaults(expression));
        }

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(BrandUpdateDTO updateDTO)
        {
            var brand = await GetById(updateDTO.ID);
            var updatedBrand = _mapper.Map(updateDTO, brand);
            await _brandRepository.Update(_mapper.Map<Brand>(updatedBrand));
        }
    }
}
