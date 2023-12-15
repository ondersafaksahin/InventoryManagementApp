using InventoryManagementApp.Application.DTOs.BatchDTOs;
using InventoryManagementApp.Application.DTOs.GoodDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.GoodService
{
    public interface IGoodService:IBaseService<GoodCreateDTO,GoodUpdateDTO, GoodListDTO, GoodDTO, Good, int>
    {
        public Task<Dictionary<int, string>> GetGoodBatches(int goodId);
        public Task<string?> GetCodeById(int? Id);
    }
}
