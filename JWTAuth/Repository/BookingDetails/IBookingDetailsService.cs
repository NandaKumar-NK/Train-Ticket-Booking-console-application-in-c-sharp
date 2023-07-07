using JWTAuth.Models;

namespace JWTAuth.Repository.BookingDetails
{
    public interface IBookingDetailsService
    {
       Task<List<BookingDetail?>> GetbookingDetail();
      // public IEnumerable<BookingDetail> GetBookingDetails();
       Task<BookingDetail> GetbookingDetail(int id);
        Task<BookingDetail> PutbookingDetail(int id, BookingDetail bookingDetail);
        Task<BookingDetail> PostbookingDetail(BookingDetail bookingDetail);
       Task<string> DeletebookingDetail(int id);
    }
}
