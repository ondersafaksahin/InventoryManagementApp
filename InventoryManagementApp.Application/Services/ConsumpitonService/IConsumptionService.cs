using InventoryManagementApp.Application.DTOs.ConsumptionDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.ConsumpitonService
{
	public interface IConsumptionService:IBaseService<ConsumptionCreateDTO, ConsumptionUpdateDTO, ConsumptionListDTO, ConsumptionDTO, Consumption,int>
	{
	}
}
