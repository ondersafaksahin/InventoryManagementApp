using AutoMapper;
using InventoryManagementApp.Application.DTOs.BatchDTOs;
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
        IInventoryRepository _inventoryRepository;
        IMapper _mapper;

        public StockTransferService(IStockTransferRepository stockTransferRepository, IMapper mapper, IGoodRepository goodRepository, IWareHouseRepository wareHouseRepository, IInventoryRepository inventoryRepository)
        {
            _stockTransferRepository = stockTransferRepository;
            _mapper = mapper;
            _inventoryRepository = inventoryRepository;
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
        public async Task Update(StockTransfer stockTransfer)
        {
            await _stockTransferRepository.Update(stockTransfer);
        }

        public async Task ReverseStockTransfer(int stockTransferId)
        {
            var stockTransfer = await _stockTransferRepository.GetById(x => x.ID == stockTransferId);
            var sourceInventory = await _inventoryRepository.FindMatchingInventory(stockTransfer.GoodId, stockTransfer.SourceWarehouseID, stockTransfer.BatchId);
            var destinationInventory = await _inventoryRepository.FindMatchingInventory(stockTransfer.GoodId, stockTransfer.DestinationWarehouseID, stockTransfer.BatchId);

            if (sourceInventory != null)
            {
                sourceInventory.Amount += stockTransfer.Amount;
                await _inventoryRepository.Update(sourceInventory);
                
            }
            else
            {
                throw new Exception("There is no inventory with specified attributes or amount");
            }

            if (destinationInventory != null)
            {
                destinationInventory.Amount -= stockTransfer.Amount;
                await _inventoryRepository.Update(destinationInventory);
               
            }
            else
            {
                throw new Exception("There is no inventory with specified attributes or amount");
            }
            await Update(stockTransfer);
        }
        public async Task CompleteStockTransfer(int stockTransferId)
        {
            var stockTransfer = await _stockTransferRepository.GetById(x => x.ID == stockTransferId);
            var sourceInventory = await _inventoryRepository.FindMatchingInventory(stockTransfer.GoodId, stockTransfer.SourceWarehouseID, stockTransfer.BatchId);
            var destinationInventory = await _inventoryRepository.FindMatchingInventory(stockTransfer.GoodId, stockTransfer.DestinationWarehouseID, stockTransfer.BatchId);

            if (destinationInventory is null)
            {
                if (stockTransfer.Amount==sourceInventory.Amount)
                {
                    sourceInventory.WarehouseId = stockTransfer.DestinationWarehouseID;
                    await _inventoryRepository.Update(sourceInventory);
                    await Update(stockTransfer);
                }
                else if (stockTransfer.Amount < sourceInventory.Amount)
                {
                    await _inventoryRepository.Add(new Inventory()
                    {
                        Amount = stockTransfer.Amount,
                        BatchId = stockTransfer.BatchId,
                        GoodId = stockTransfer.GoodId,
                        WarehouseId = stockTransfer.DestinationWarehouseID
                    });
                    sourceInventory.Amount -= stockTransfer.Amount;
                    await _inventoryRepository.Update(sourceInventory);
                    await Update(stockTransfer);
                }
                else
                {
                    throw new Exception("There is no inventory with specified attributes or amount");
                }
            }
            else
            {
                if (sourceInventory is null)
                {
                    throw new Exception("There is no inventory with specified attributes or amount");
                }
                else
                {
                    if (stockTransfer.Amount == sourceInventory.Amount)
                    {
                        destinationInventory.Amount += stockTransfer.Amount;
                        await _inventoryRepository.Delete(sourceInventory);
                        await Update(stockTransfer);
                    }
                    else if (stockTransfer.Amount < sourceInventory.Amount)
                    {
                        destinationInventory.Amount += stockTransfer.Amount;
                        sourceInventory.Amount -= stockTransfer.Amount;
                        await _inventoryRepository.Update(sourceInventory);
                        await _inventoryRepository.Update(destinationInventory);
                        await Update(stockTransfer);
                    }
                    else
                    {
                        throw new Exception("There is no inventory with specified attributes or amount");
                    }
                }  
            }
        }

    }
}
