using JWTAuth.Models;

namespace JWTAuth.Repository.BookingDetails
{
    public interface ISeatService
    {
        Task<IEnumerable<Seat>> GetSeats();
        Task<Seat> GetSeat(int id);
        Task<Seat> PutSeat(int id, Seat seat);
        Task<Seat> PostSeat(Seat seat);
        Task<String> DeleteSeat(int id);

    }
}
