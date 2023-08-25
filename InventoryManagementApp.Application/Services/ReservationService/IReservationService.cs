using InventoryManagementApp.Application.DTOs.ReservationDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.ReservationService
{
	public interface IReservationService:IBaseService<ReservationCreateDTO,ReservationUpdateDTO,ReservationListDTO,ReservationDTO,Reservation,int>
	{
	}
}
