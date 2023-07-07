using JWTAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.Repository.BookingDetails
{
    public class SeatAllocationService:ISeatAllocationService
    {
        public TrainTicketBookingContext _context;
        public SeatAllocationService(TrainTicketBookingContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SeatAllocation>> GetSeatAllocation()
        {
            var students = await _context.SeatAllocations.ToListAsync();
            return students;
        }

        public async Task<SeatAllocation> GetSeatAllocation(int id)
        {
            var td = await _context.SeatAllocations.FirstOrDefaultAsync(x => x.TrainId == id);

            if (td is null)
            {
                return null;
            }
            return td;

        }
        public async Task<SeatAllocation> PutSeatAllocation(int id, SeatAllocation seatAllocation)
        {
            var td = await _context.SeatAllocations.FirstOrDefaultAsync(x => x.TrainId == id);
            td.SeatNo = seatAllocation.SeatNo;
            td.Train = seatAllocation.Train;
            td.Fare = seatAllocation.Fare;
            td.SeatStatus = seatAllocation.SeatStatus;
            await _context.SaveChangesAsync();
            return td;
        }

        public async Task<SeatAllocation> PostSeatAllocation(SeatAllocation seatAllocation)
        {
            await _context.SeatAllocations.AddAsync(seatAllocation);
            _context.SaveChangesAsync();
            return seatAllocation;
        }

        public async Task<string> DeleteSeatAllocation(int id)
        {
            var dep = await _context.TrainDetails.FirstOrDefaultAsync(x => x.TrainId == id);
            _context.Remove(dep);
            _context.SaveChanges();

            return "Deleted successfully";
        }


    }
}
