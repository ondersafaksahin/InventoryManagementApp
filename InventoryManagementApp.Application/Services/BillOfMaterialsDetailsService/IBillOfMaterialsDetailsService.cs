using InventoryManagementApp.Application.DTOs.BillOfMaterialsDetailsDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.BillOfMaterialsDetailsService
{
	public interface IBillOfMaterialsDetailsService:IBaseService<BillOfMaterialsDetailsCreateDTO, BillOfMaterialsDetailsUpdateDTO, BillOfMaterialsDetailsListDTO, BillOfMaterialsDetailsDTO, BillOfMaterialDetails,int>
	{
	}
}
