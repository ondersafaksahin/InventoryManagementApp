using AutoMapper;
using InventoryManagementApp.Application.DTOs.SubCategoryDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.SubCategoryService
{
	public class SubCategoryService : ISubCategoryService
	{
		ISubCategoryRepository _subCategoryRepository;
		ICategoryRepository _categoryRepository;
		IMapper _mapper;
        public SubCategoryService(IMapper mapper, ISubCategoryRepository subCategoryRepository, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _subCategoryRepository = subCategoryRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<List<SubCategoryListDTO>> All()
		{
            var list = _mapper.Map<List<SubCategoryListDTO>>(await _subCategoryRepository.GetAll());
            var category = await _categoryRepository.GetAll();
            foreach (var item in list)
            {
                foreach (var ct in category)
                {
                    if (ct.ID == item.CategoryID)
                    {
                        item.Category = ct;
                    }
                }
            }

            return list;

        }

		public async Task Create(SubCategoryCreateDTO createDTO)
		{
			await _subCategoryRepository.Add(_mapper.Map<SubCategory>(createDTO));
		}

		public async Task Delete(int id)
		{
			await _subCategoryRepository.Delete(await _subCategoryRepository.GetById(x=>x.ID==id));
		}

		public async Task<SubCategoryDTO> GetById(int id)
		{
			return _mapper.Map<SubCategoryDTO>(await _subCategoryRepository.GetById(x => x.ID == id));
		}

		public async Task<List<SubCategoryListDTO>> GetDefaults(Expression<Func<SubCategory, bool>> expression)
		{
            var list = _mapper.Map<List<SubCategoryListDTO>>(await _subCategoryRepository.GetDefaults(expression));
            var category = await _categoryRepository.GetAll();
            foreach (var item in list)
            {
                foreach (var ct in category)
                {
                    if (ct.ID == item.CategoryID)
                    {
                        item.Category = ct;
                    }
                }
            }

            return list;

        }

		public async Task Update(SubCategoryUpdateDTO updateDTO)
		{
			await _subCategoryRepository.Update(_mapper.Map<SubCategory>(updateDTO));
		}
	}
}
