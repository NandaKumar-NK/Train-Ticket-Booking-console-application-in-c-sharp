using JWTAuth.Models;

namespace JWTAuth.Repository.BookingDetails
{
    public interface ISeatAllocationService
    {
        Task<IEnumerable<SeatAllocation>> GetSeatAllocation();
        Task<SeatAllocation> GetSeatAllocation(int id);
        Task<SeatAllocation> PutSeatAllocation(int id, SeatAllocation seatAllocation);
        Task<SeatAllocation> PostSeatAllocation(SeatAllocation seatAllocation);
        Task<string> DeleteSeatAllocation(int id);
    }
}
