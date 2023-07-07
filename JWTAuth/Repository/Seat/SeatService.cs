using JWTAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.Repository.BookingDetails
{
    public class SeatService:ISeatService
    {
        public readonly TrainTicketBookingContext _context;
        public SeatService(TrainTicketBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Seat>> GetSeats()
        {
            var se = await _context.Seats.ToListAsync();
            return se;
        }
        public async Task<Seat> GetSeat(int id)
        {
            var td = await _context.Seats.FirstOrDefaultAsync(x => x.TrainId== id);

            if (td is null)
            {
                return null;
            }
            return td;
        }
        public async Task<Seat> PutSeat(int id, Seat seat)
        {
            var td = await _context.Seats.FirstOrDefaultAsync(x => x.SeatId == id);
            td.TrainId = seat.TrainId;
            td.CompartmentCount = seat.CompartmentCount;    
            td.CompartmentType = seat.CompartmentType;
            await _context.SaveChangesAsync();
            return seat;
        }

        public async Task<Seat> PostSeat(Seat seat)
        {
            await _context.Seats.AddAsync(seat);
            _context.SaveChangesAsync();
            return seat;
        }

        public async Task<String> DeleteSeat(int id)
        {

            var se = await _context.Seats.FirstOrDefaultAsync(x => x.SeatId == id);
            _context.Remove(se);
            _context.SaveChanges();

            return "Deleted successfully";
        }
    }
}
