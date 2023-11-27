using InventoryManagementApp.Application.DTOs.BrandDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.BrandService
{
    public interface IBrandService:IBaseService<BrandCreateDTO,BrandUpdateDTO,BrandListDTO,BrandDTO,Brand,int>
    {
    }
}
