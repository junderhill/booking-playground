﻿using BookingTDD.Command.RepositoryContracts;
using BookingTDD.Command.Requests;
using BookingTDD.Core.Domain;
using BookingTDD.Core.RepositoryContracts;
using MediatR;

namespace BookingTDD.Command.Handlers
 {
     public class CreateBookingHandler : IRequestHandler<CreateBookingRequest, Booking>
     {
         private readonly IBookingRepository _bookingRepository;
         private readonly IRoomRepository _roomRepository;
 
         public CreateBookingHandler(IBookingRepository bookingRepository, IRoomRepository roomRepository)
         {
             _bookingRepository = bookingRepository;
             _roomRepository = roomRepository;
         }
         
         public Booking Handle(CreateBookingRequest message)
         {
             var room = _roomRepository.GetRoomById(message.RoomId);
             
             var bookingPeriod = new BookingPeriod(message.StartTime, message.EndTime);
             var booking = Booking.Create(bookingPeriod, room);
 
             _bookingRepository.CreateBooking(booking);
 
             return booking;
         }
     }
 }