using InventoryManagementApp.Application.DTOs.ModelDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.ModelService
{
    public interface IModelService:IBaseService<ModelCreateDTO,ModelUpdateDTO,ModelListDTO,ModelDTO,Model,int>
    {
    }
}
