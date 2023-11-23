using InventoryManagementApp.Application.DTOs.DeliveryDTOs;
using InventoryManagementApp.Application.DTOs.GoodsReceiptDetailDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.GoodsReceiptDetailService
{
    public interface IGoodsReceiptDetailService : IBaseService<GoodsReceiptDetailCreateDTO, GoodsReceiptDetailUpdateDTO, GoodsReceiptDetailListDTO, GoodsReceiptDetailDTO, GoodsReceiptDetail, int>
    
    {
    }
}
