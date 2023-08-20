using InventoryManagementApp.Application.DTOs.BillOfMaterialsDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.BillOfMaterialsService
{
    public interface IBillOfMatieralsService:IBaseService<BOMCreateDTO,BOMUpdateDTO,BOMListDTO,BOMDTO,BillOfMaterial,int>
    {
    }
}
