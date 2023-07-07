using JWTAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.Repository.BookingDetails
{
    public class BookingdetailsService : IBookingDetailsService
    {
        private readonly TrainTicketBookingContext _context;

       public BookingdetailsService(TrainTicketBookingContext context)
        {
            _context = context;
        }
        /* public IEnumerable<BookingDetail> GetBookingDetails()
         {
             return _context.BookingDeatils.ToList();
         }
         public Task<BookingDetail> GetbookingDetail(int id)
         {
             BookingDetail bk = _context.BookingDeatils.First(x => x.TicketId == id);
             return bk;

         }
        */
        public async Task<string> DeletebookingDetail(int id)
        {
            var bookingDetail = await _context.BookingDeatils.FirstOrDefaultAsync(x => x.TicketId == id);
            _context.Remove(bookingDetail);
            _context.SaveChanges();

            return "Deleted successfully";
        }

        public async Task<List<BookingDetail?>> GetbookingDetail()
        {
            return await _context.BookingDeatils.ToListAsync();
        }

        public async Task<BookingDetail> GetbookingDetail(int id)
        {
            var td = await _context.BookingDeatils.FirstOrDefaultAsync(x => x.TicketId == id);

            if (td is null)
            {
                return null;
            }
            return td;
        }

        public async Task<BookingDetail> PostbookingDetail(BookingDetail bookingDetail)
        {
            await _context.BookingDeatils.AddAsync(bookingDetail);
            _context.SaveChangesAsync();
            return bookingDetail;
        }

        public async Task<BookingDetail> PutbookingDetail(int id, BookingDetail bookingDetail)
        {
            var td = await _context.BookingDeatils.FirstOrDefaultAsync(x => x.TicketId == id);
            td.SeatNo = bookingDetail.SeatNo;
            td.CompartmentType = bookingDetail.CompartmentType;
            td.Train = bookingDetail.Train;
            td.TDate = bookingDetail.TDate;

            await _context.SaveChangesAsync();
            return td;


        }

    }
}
