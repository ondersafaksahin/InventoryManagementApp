using AutoMapper;
using InventoryManagementApp.Application.DTOs.StockTransferDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
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
        IMapper _mapper;

        public StockTransferService(IStockTransferRepository stockTransferRepository, IMapper mapper)
        {
            _stockTransferRepository = stockTransferRepository;
            _mapper = mapper;
        }
        public async Task<List<StockTransferListDTO>> All()
        {
            return _mapper.Map<List<StockTransferListDTO>>(await _stockTransferRepository.GetAll());
        }

        public async Task Create(StockTransferCreateDTO createDTO)
        {
            var stockTransfer = _mapper.Map<StockTransfer>(createDTO);
            await _stockTransferRepository.Add(stockTransfer);
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
            return _mapper.Map<List<StockTransferListDTO>>(await _stockTransferRepository.GetDefaults(expression));
        }

        public async Task Update(StockTransferUpdateDTO updateDTO)
        {
            await _stockTransferRepository.Update(_mapper.Map<StockTransfer>(updateDTO));
        }
    }
}
