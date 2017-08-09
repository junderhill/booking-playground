using BookingTDD.Core.Domain;

namespace BookingTDD.Command.RepositoryContracts
{
    public interface IRoomRepository
    {
        Room GetRoomById(int messageRoomId);
    }
}