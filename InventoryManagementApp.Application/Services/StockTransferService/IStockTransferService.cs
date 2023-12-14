using InventoryManagementApp.Application.DTOs.StockTransferDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.StockTransferService
{
    public interface IStockTransferService:IBaseService<StockTransferCreateDTO, StockTransferUpdateDTO, StockTransferListDTO, StockTransferDTO, StockTransfer, int>
    {
        public Task CompleteStockTransfer(int stockTransferId);
        public Task ReverseStockTransfer(int stockTransferId);
        public Task Update(StockTransfer stockTransfer);
    }
}
