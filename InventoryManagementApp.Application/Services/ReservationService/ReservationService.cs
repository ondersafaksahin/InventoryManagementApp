using AutoMapper;
using InventoryManagementApp.Application.DTOs.ReservationDTOs;
using InventoryManagementApp.Domain.Entities.Concrete;
using InventoryManagementApp.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.ReservationService
{
	public class ReservationService : IReservationService
	{
		IReservationRepository _reservationRepostitory;
		IMapper _mapper;
		public ReservationService(IReservationRepository reservationRepostitory, IMapper mapper)
		{
			_reservationRepostitory = reservationRepostitory;
			_mapper = mapper;
		}
		public async Task<List<ReservationListDTO>> All()
		{
			return _mapper.Map<List<ReservationListDTO>>(await _reservationRepostitory.GetAll());
		}

		public async Task<int> Create(ReservationCreateDTO createDTO)
		{
			var reservation = _mapper.Map<Reservation>(createDTO);
            await _reservationRepostitory.Add(reservation);
			return reservation.ID;
		}

		public async Task Delete(int id)
		{
			await _reservationRepostitory.Delete(_mapper.Map<Reservation>(await GetById(id)));
		}

		public async Task<ReservationDTO> GetById(int id)
		{
			return _mapper.Map<ReservationDTO>(await _reservationRepostitory.GetById(x => x.ID == id));
		}

		public async Task<List<ReservationListDTO>> GetDefaults(Expression<Func<Reservation, bool>> expression)
		{
			return _mapper.Map<List<ReservationListDTO>>(await _reservationRepostitory.GetDefaults(expression));
		}

        public Task<string?> GetNameById(int? Id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(ReservationUpdateDTO updateDTO)
		{
			await _reservationRepostitory.Update(_mapper.Map<Reservation>(updateDTO));
		}
	}
}
