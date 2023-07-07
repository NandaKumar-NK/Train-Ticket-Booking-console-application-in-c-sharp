using JWTAuth.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.Repository.BookingDetails
{
    public class PassangerDetailsService:IPassangerDetailsService
    {


        private readonly TrainTicketBookingContext _context;
        public PassangerDetailsService(TrainTicketBookingContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PassangerDetail>> GetPassangerDetails()
        {
            var pas = await _context.PassangerDetails.ToListAsync();
            return pas;
        }
        public async Task<PassangerDetail> GetPassangerDetail(int id)
        {
            var td = await _context.PassangerDetails.FirstOrDefaultAsync(x => x.PassId== id);

           
            return td;
        }
        public async Task<PassangerDetail> PutPassangerDetail(int id, PassangerDetail passangerDetail)
        {
            var td = await _context.PassangerDetails.FirstOrDefaultAsync(x => x.PassId == id);
            td.PassangerEmailid = passangerDetail.PassangerEmailid;
            td.Password = passangerDetail.Password;
            await _context.SaveChangesAsync();
            return passangerDetail;
        }

        public async Task<PassangerDetail> PostPassangerDetail(PassangerDetail passangerDetail)
        {
            await _context.PassangerDetails.AddAsync(passangerDetail);
            _context.SaveChangesAsync();
            return passangerDetail;
        }
        public async Task<string> DeletePassangerDetail(int id)
        {
            var passDetail = await _context.PassangerDetails.FirstOrDefaultAsync(x => x.PassId == id);
            _context.Remove(passDetail);
            _context.SaveChanges();

            return "Deleted successfully";
        }
    }
}
