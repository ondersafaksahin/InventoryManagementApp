using AutoMapper;
using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.CategoryService
{
	public class CategoryService : ICategoryService
	{
		ICategoryRepository _categoryRepository;
		IMapper _mapper;
        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
			_mapper = mapper;
			_categoryRepository = categoryRepository;
		}
        public async Task<List<CategoryListDTO>> All()
		{
			return _mapper.Map<List<CategoryListDTO>>(await _categoryRepository.GetAll());
		}

		public async Task<int> Create(CategoryCreateDTO createDTO)
		{
            var category = _mapper.Map<Category>(createDTO);
            await _categoryRepository.Add(category);
            return category.ID;
        }

        public async Task Delete(int id)
		{
			await _categoryRepository.Delete(await _categoryRepository.GetById(x => x.ID == id));
		}

		public async Task<CategoryDTO> GetById(int id)
		{
			return _mapper.Map<CategoryDTO>(await _categoryRepository.GetById(x => x.ID == id));
		}

		public async Task<List<CategoryListDTO>> GetDefaults(Expression<Func<Category, bool>> expression)
		{
			return _mapper.Map<List<CategoryListDTO>>(await _categoryRepository.GetDefaults(expression));
		}

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(CategoryUpdateDTO updateDTO)
		{
            await _categoryRepository.Update(_mapper.Map<Category>(updateDTO));
        }
	}
}
