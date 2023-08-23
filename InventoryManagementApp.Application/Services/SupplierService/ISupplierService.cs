using InventoryManagementApp.Application.DTOs.SupplierDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.SupplierService
{
	public interface ISupplierService:IBaseService<SupplierCreateDTO,SupplierUpdateDTO,SupplierListDTO,SupplierDTO,Supplier,int>
	{
	}
}
