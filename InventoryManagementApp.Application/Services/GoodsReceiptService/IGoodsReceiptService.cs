using InventoryManagementApp.Application.DTOs.DeliveryDTOs;
using InventoryManagementApp.Application.DTOs.GoodsReceiptDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.GoodsReceiptService
{
    public interface IGoodsReceiptService : IBaseService<GoodsReceiptCreateDTO, GoodsReceiptUpdateDTO, GoodsReceiptListDTO, GoodsReceiptDTO, GoodsReceipt, int>
    {
    }
}
