using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Commands.Booking.DTO;
using Unik.Application.Mappers;
using Unik.Application.Repositories;
using Unik.Application.Repository;
using Unik.Domain.Ínterfaces;

namespace Unik.Application.Commands.Booking.Implementation
{
    public class EditBookingCommand : IEditBookingCommand
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IItemMapper _itemMapper;

        public EditBookingCommand(IBookingRepository bookingRepository, IItemRepository itemRepository, IItemMapper itemMapper)
        {
            _bookingRepository = bookingRepository;
            _itemRepository = itemRepository;

            _itemMapper = itemMapper;
        }

        void IEditBookingCommand.Edit(BookingEditRequestDto dto)
        {
            var booking = _bookingRepository.Load(dto.Id);
            if (booking == null)
            {
                throw new Exception("Booking not found");
            }

            // Hent items fra repository
            booking.Edit(dto.Item, dto.StartDate, dto.EndDate);
            _bookingRepository.UpdateBooking(booking);
        }
    }
}
  

