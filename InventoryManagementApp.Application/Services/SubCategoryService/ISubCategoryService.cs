using InventoryManagementApp.Application.DTOs.SubCategoryDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.SubCategoryService
{
	public interface ISubCategoryService:IBaseService<SubCategoryCreateDTO,SubCategoryUpdateDTO,SubCategoryListDTO,SubCategoryDTO,SubCategory,int>
	{
		public Task<int> CreateModal(SubCategoryCreateDTO createDTO);
	}
}
