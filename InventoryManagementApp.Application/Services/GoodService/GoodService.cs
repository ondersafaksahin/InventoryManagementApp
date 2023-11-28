using AutoMapper;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.GoodService
{
    public class GoodService : IGoodService
    {
        IGoodRepository _goodRepository;
        ICategoryRepository _categoryRepository;
        ISubCategoryRepository _subCategoryRepository;
        IBrandRepository _brandRepository;
        IMapper _mapper;

        public GoodService(IGoodRepository goodRepository, IMapper mapper, ICategoryRepository categoryRepository, ISubCategoryRepository subCategoryRepository, IBrandRepository brandRepository)
        {
            _goodRepository = goodRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _subCategoryRepository = subCategoryRepository;
            _brandRepository = brandRepository;
        }

        public async Task<List<GoodListDTO>> All()
        {

            return _mapper.Map<List<GoodListDTO>>(await _goodRepository.GetAll());
            //var list = _mapper.Map<List<GoodListDTO>>(await _goodRepository.GetAll());

            //foreach (var item in list)
            //{
            //    var category = _categoryRepository.GetById(x => x.ID == item.CategoryID);
            //    item.Category = category.Result;

            //    var subcategory = _subCategoryRepository.GetById(x => x.ID == item.SubCategoryID);
            //    item.SubCategory = subcategory.Result;

            //    var brand = _brandRepository.GetById(x => x.ID == item.BrandID);
            //    item.Brand = brand.Result;

            //    if (item.ModelID != null)
            //    {
            //        var model = _modelRepository.GetById(x => x.ID == item.ModelID);
            //        item.Model = model.Result;
            //    }


            //}
            //return list;
        }

        public async Task<int> Create(GoodCreateDTO createDTO)
        {
            var good = _mapper.Map<Good>(createDTO);
            await _goodRepository.Add(good);
            return good.ID;
        }

        public async Task Delete(int id)
        {
            await _goodRepository.Delete(await _goodRepository.GetById(x => x.ID == id));
         
        }

        public async Task<GoodDTO> GetById(int id)
        {
           return _mapper.Map<GoodDTO>(await _goodRepository.GetById(x => x.ID == id));
        }

        public async Task<List<GoodListDTO>> GetDefaults(Expression<Func<Good, bool>> expression)
        {
            var list = _mapper.Map<List<GoodListDTO>>(await _goodRepository.GetDefaults(expression));


            //foreach (var item in list)
            //{
            //    var category = _categoryRepository.GetById(x => x.ID == item.CategoryID);
            //    item.Category = category.Result;

            //    var subcategory = _subCategoryRepository.GetById(x => x.ID == item.SubCategoryID);
            //    item.SubCategory = subcategory.Result;

            //    var brand = _brandRepository.GetById(x => x.ID == item.BrandID);
            //    item.Brand = brand.Result;

            //    var model = _modelRepository.GetById(x => x.ID == item.ModelID);
            //    item.Model = model.Result;

            //}

            return list;
        }

        public async Task<string?> GetNameById(int? Id)
        {
            var good = await _goodRepository.GetById(x => x.ID == Id);
            return good?.Name;
        }

        public async Task Update(GoodUpdateDTO updateDTO)
        {
            var good = await GetById(updateDTO.ID);
            var updatedGood = _mapper.Map(updateDTO, good);
            await _goodRepository.Update(_mapper.Map<Good>(updatedGood));
        }
    }
}
