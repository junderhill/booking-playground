using System;
using BookingTDD.Core.Domain;
using MediatR;

namespace BookingTDD.Command.Requests
{
    public class CreateBookingRequest : IRequest<Booking>
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int RoomId { get; set; }
        public string Organiser { get; set; }
    }
}