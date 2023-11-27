using InventoryManagementApp.Application.DTOs.CategoryDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.CategoryService
{
	public interface ICategoryService:IBaseService<CategoryCreateDTO,CategoryUpdateDTO,CategoryListDTO,CategoryDTO,Category,int>
	{
	}
}
