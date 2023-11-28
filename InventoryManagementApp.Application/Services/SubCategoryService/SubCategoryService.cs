using AutoMapper;
using InventoryManagementApp.Application.DTOs.SubCategoryDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System.Linq.Expressions;


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

            foreach (var item in list)
            {
                var category = _categoryRepository.GetById(x => x.ID == item.CategoryID);
                item.Category = category.Result;
             
            }
            return list;

        }

		public async Task<int> Create(SubCategoryCreateDTO createDTO)
		{
            var subcategory = _mapper.Map<SubCategory>(createDTO);
            await _subCategoryRepository.Add(subcategory);
            return subcategory.ID;
		}

        public async Task<int> CreateModal(SubCategoryCreateDTO createDTO)
        {
            var subcategory = _mapper.Map<SubCategory>(createDTO);
            await _subCategoryRepository.Add(subcategory);
            return subcategory.ID;
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

            foreach (var item in list)
            {
                var category1 = _categoryRepository.GetById(x => x.ID == item.CategoryID);
                item.Category = category1.Result;              
            }

            return list;

        }

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(SubCategoryUpdateDTO updateDTO)
		{
            var subCategory = await GetById(updateDTO.ID);
            var updatedSubCategory = _mapper.Map(updateDTO, subCategory);
			await _subCategoryRepository.Update(_mapper.Map<SubCategory>(updatedSubCategory));
		}

        
    }
}
