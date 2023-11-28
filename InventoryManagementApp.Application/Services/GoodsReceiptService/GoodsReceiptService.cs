using AutoMapper;
using InventoryManagementApp.Application.DTOs.GoodsReceiptDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.GoodsReceiptService
{
    public class GoodsReceiptService: IGoodsReceiptService
    {
        IGoodsReceiptRepository _goodsReceiptRepository;
        IMapper _mapper;
        public GoodsReceiptService(IGoodsReceiptRepository goodsReceiptRepository, IMapper mapper)
        {
            _goodsReceiptRepository = goodsReceiptRepository;
            _mapper = mapper;
        }

        public async Task<List<GoodsReceiptListDTO>> All()
        {
            return _mapper.Map<List<GoodsReceiptListDTO>>(await _goodsReceiptRepository.GetAll());
        }

        public async Task<int> Create(GoodsReceiptCreateDTO createDTO)
        {
            var goodsReceipt = _mapper.Map<GoodsReceipt>(createDTO);
            await _goodsReceiptRepository.Add(goodsReceipt);
            return goodsReceipt.ID;
        }

        public async Task Delete(int id)
        {
            await _goodsReceiptRepository.Delete(await _goodsReceiptRepository.GetById(x => x.ID == id));
        }

        public async Task<GoodsReceiptDTO> GetById(int id)
        {
            return _mapper.Map<GoodsReceiptDTO>(await _goodsReceiptRepository.GetById(x => x.ID == id));
        }

        public async Task<List<GoodsReceiptListDTO>> GetDefaults(Expression<Func<GoodsReceipt, bool>> expression)
        {
            return _mapper.Map<List<GoodsReceiptListDTO>>(await _goodsReceiptRepository.GetDefaults(expression));
        }

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(GoodsReceiptUpdateDTO updateDTO)
        {
            await _goodsReceiptRepository.Update(_mapper.Map<GoodsReceipt>(updateDTO));
        }
    }
}
