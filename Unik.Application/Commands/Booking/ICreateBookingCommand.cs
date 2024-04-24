﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Application.Commands.Booking.DTO;

namespace Unik.Application.Commands.Booking
{
    public interface ICreateBookingCommand
    {
        void CreateBooking(BookingCreateDto bookingCreateDto);//Void så de kan afvikles i seperat tråd
    }
}
