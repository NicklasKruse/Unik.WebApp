using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Commands.Booking.DTO;
using Unik.Application.Repository;
using Unik.Domain.Ínterfaces;
using Unik.Domain.Models;

namespace Unik.Application.Commands.Booking.Implementation
{
    //public class CreateBookingCommand : ICreateBookingCommand
    //{
    //    private readonly IBookingRepository _bookingRepository;
    //    public CreateBookingCommand(IBookingRepository bookingRepository)
    //    {
    //        _bookingRepository = bookingRepository;
    //    }
    //    void ICreateBookingCommand.CreateBooking(BookingCreateDto dto)
    //    {
    //        var id = _bookingRepository.GetNextKey();
    //        //var booking = new Booking(id, dto.BookingItems, dto.BookingDates);
    //        _bookingRepository.AddBooking(booking);
    //    }
    //}
}
