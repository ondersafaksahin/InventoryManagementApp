using InventoryManagementApp.Application.DTOs.ConversionDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.ConversionService
{
	public interface IConversionService:IBaseService<ConversionCreateDTO, ConversionUpdateDTO, ConversionListDTO, ConversionDTO,Conversion,int>
	{
	}
}
