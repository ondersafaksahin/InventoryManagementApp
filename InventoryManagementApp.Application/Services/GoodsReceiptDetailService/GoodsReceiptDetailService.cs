using AutoMapper;
using InventoryManagementApp.Application.DTOs.DeliveryDTOs;
using InventoryManagementApp.Application.DTOs.GoodsReceiptDetailDTOs;
using InventoryManagementApp.Application.DTOs.GoodsReceiptDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.GoodsReceiptDetailService
{
    public class GoodsReceiptDetailService : IGoodsReceiptDetailService
    {
        IGoodsReceiptDetailRepository _goodsReceiptDetailRepository;
        IMapper _mapper;
        public GoodsReceiptDetailService(IGoodsReceiptDetailRepository goodsReceiptDetailRepository, IMapper mapper)
        {
            _goodsReceiptDetailRepository = goodsReceiptDetailRepository;
            _mapper = mapper;
        }

        public async Task<List<GoodsReceiptDetailListDTO>> All()
        {
            return _mapper.Map<List<GoodsReceiptDetailListDTO>>(await _goodsReceiptDetailRepository.GetAll());
        }

        public async Task<int> Create(GoodsReceiptDetailCreateDTO createDTO)
        {
            var goodsReceiptDetail = _mapper.Map<GoodsReceiptDetail>(createDTO);
            await _goodsReceiptDetailRepository.Add(goodsReceiptDetail);
            return goodsReceiptDetail.ID;
        }

        public async Task Delete(int id)
        {
            await _goodsReceiptDetailRepository.Delete(await _goodsReceiptDetailRepository.GetById(x => x.ID == id));
        }

        public async Task<GoodsReceiptDetailDTO> GetById(int id)
        {
            return _mapper.Map<GoodsReceiptDetailDTO>(await _goodsReceiptDetailRepository.GetById(x => x.ID == id));
        }

        public async Task<List<GoodsReceiptDetailListDTO>> GetDefaults(Expression<Func<GoodsReceiptDetail, bool>> expression)
        {
            return _mapper.Map<List<GoodsReceiptDetailListDTO>>(await _goodsReceiptDetailRepository.GetDefaults(expression));
        }

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(GoodsReceiptDetailUpdateDTO updateDTO)
        {
            await _goodsReceiptDetailRepository.Update(_mapper.Map<GoodsReceiptDetail>(updateDTO));
        }
    }
}
