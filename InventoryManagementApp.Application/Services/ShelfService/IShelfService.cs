using InventoryManagementApp.Application.DTOs.ShelfDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.ShelfService
{
    public interface IShelfService:IBaseService<ShelfCreateDTO,ShelfUpdateDTO, ShelfListDTO, ShelfDTO, Shelf, int>
    {
    }
}
