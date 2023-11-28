using AutoMapper;
using InventoryManagementApp.Application.DTOs.InventoryDTOs;
using InventoryManagementApp.Application.DTOs.StockTransferDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.StockTransferService
{
    public class StockTransferService:IStockTransferService
    {
        IStockTransferRepository _stockTransferRepository;
        IGoodRepository _goodRepository;
        IWareHouseRepository _wareHouseRepository;
        IMapper _mapper;

        public StockTransferService(IStockTransferRepository stockTransferRepository, IMapper mapper, IGoodRepository goodRepository, IWareHouseRepository wareHouseRepository)
        {
            _stockTransferRepository = stockTransferRepository;
            _mapper = mapper;
            _goodRepository = goodRepository;
            _wareHouseRepository = wareHouseRepository;
        }
        public async Task<List<StockTransferListDTO>> All()
        {
            var list = _mapper.Map<List<StockTransferListDTO>>(await _stockTransferRepository.GetAll());           
            return list;
        }

        public async Task<int> Create(StockTransferCreateDTO createDTO)
        {
            var stockTransfer = _mapper.Map<StockTransfer>(createDTO);
            await _stockTransferRepository.Add(stockTransfer);
            return stockTransfer.ID;
        }

        public async Task Delete(int id)
        {
            await _stockTransferRepository.Delete(await _stockTransferRepository.GetById(x => x.ID == id));
        }

        public async Task<StockTransferDTO> GetById(int id)
        {
            var stockTransfer = await _stockTransferRepository.GetById(x => x.ID == id);
            return _mapper.Map<StockTransferDTO>(stockTransfer);
        }

        public async Task<List<StockTransferListDTO>> GetDefaults(Expression<Func<StockTransfer, bool>> expression)
        {
            var list = _mapper.Map<List<StockTransferListDTO>>(await _stockTransferRepository.GetDefaults(expression));
            return list;
        }

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(StockTransferUpdateDTO updateDTO)
        {
            await _stockTransferRepository.Update(_mapper.Map<StockTransfer>(updateDTO));
        }

    }
}
