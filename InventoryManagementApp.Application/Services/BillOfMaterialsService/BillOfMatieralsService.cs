using AutoMapper;
using InventoryManagementApp.Application.DTOs.BillOfMaterialsDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.BillOfMaterialsService
{
    public class BillOfMatieralsService : IBillOfMatieralsService
    {
        IBillOfMaterialRepository _billOfMaterialRepository;
        IMapper _mapper;

        public BillOfMatieralsService(IBillOfMaterialRepository billOfMaterialRepository, IMapper mapper)
        {
            _billOfMaterialRepository = billOfMaterialRepository;
            _mapper = mapper;
        }


        public async Task<List<BOMListDTO>> All()
        {
            return _mapper.Map<List<BOMListDTO>>(await _billOfMaterialRepository.GetAll());
        }

        public async Task<int> Create(BOMCreateDTO itemDTO)
        {
            var bom = _mapper.Map<BillOfMaterial>(itemDTO);
            await _billOfMaterialRepository.Add(bom);
            return bom.ID;
        }

        public async Task Delete(int id)
        {
            await _billOfMaterialRepository.Delete(await _billOfMaterialRepository.GetById(x => x.ID == id));
        }

        public async Task<BOMDTO> GetById(int id)
        {
            var bom = await _billOfMaterialRepository.GetById(x => x.ID == id);
            return _mapper.Map<BOMDTO>(bom);
        }

        public async Task<List<BOMListDTO>> GetDefaults(Expression<Func<BillOfMaterial, bool>> expression)
        {
            return _mapper.Map<List<BOMListDTO>>(await _billOfMaterialRepository.GetDefaults(expression));
        }

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(BOMUpdateDTO itemDTO)
        {
            await _billOfMaterialRepository.Update(_mapper.Map<BillOfMaterial>(itemDTO));
        }
    }
}
