using System;
using System.Collections.Generic;
using BookingTDD.Command.Events;
using BookingTDD.Command.Handlers;
using BookingTDD.Command.RepositoryContracts;
using BookingTDD.Command.Requests;
using BookingTDD.Core.Domain;
using BookingTDD.Core.RepositoryContracts;
using Moq;
using Xunit;

namespace BookingTDD.Command.Tests
{
    public class CreateBookingHandlerTests
    {
        private Mock<IBookingRepository> _bookingRepository;
        private Mock<IRoomRepository> _roomRepository;
        private Mock<IDomainEvents> _domainEvents;

        public CreateBookingHandlerTests()
        {
            _bookingRepository = new Mock<IBookingRepository>();
            _roomRepository = new Mock<IRoomRepository>();
            _domainEvents = new Mock<IDomainEvents>();
            MockSetup();
        }

        private void MockSetup()
        {
            _roomRepository.Setup(x => x.GetRoomById(It.IsAny<int>()))
                .Returns(new Room(1, "Conference Room", 100) {Bookings = new List<Booking>()});
        }
        private CreateBookingHandler CreateSUT()
        {
                return new CreateBookingHandler(_bookingRepository.Object, _roomRepository.Object, _domainEvents.Object);
        }
        private static CreateBookingRequest CreateBookingRequest()
        {
            var bookingRequest = new CreateBookingRequest()
            {
                RoomId = 1,
                Organiser = "test",
                StartTime = new DateTime(2018, 1, 1, 10, 30, 0),
                EndTime = new DateTime(2018, 1, 1, 11, 30, 0),
            };
            return bookingRequest;
        }

        [Fact]
        public void CreatingABookingPublishesACreatedEvent()
        {
            //arrange
            var createBookingHandler = CreateSUT();
            //act
            createBookingHandler.Handle(CreateBookingRequest());
            //assert
            _domainEvents.Verify(x => x.PublishEvent(It.IsAny<BookingCreatedEvent>()));
        }

        [Fact]
        public void CreatingABookingAttemptsToPersistTheBooking()
        {
            //arrange
            var createBookingHandler = CreateSUT();
            //act
            var bookingRequest = CreateBookingRequest();
            var booking = createBookingHandler.Handle(bookingRequest);
            //assert
            _bookingRepository.Verify(x => x.CreateBooking(It.Is<Booking>(b => 
                b.BookingPeriod.Start == bookingRequest.StartTime && 
                b.BookingPeriod.End == bookingRequest.EndTime )));
        }
    }
}