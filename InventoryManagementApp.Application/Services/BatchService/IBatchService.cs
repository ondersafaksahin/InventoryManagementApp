using InventoryManagementApp.Application.DTOs.BatchDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.BatchService
{
    public interface IBatchService:IBaseService<BatchCreateDTO,BatchUpdateDTO,BatchListDTO,BatchDTO,Batch,int>
    {
    }
}
