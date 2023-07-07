using JWTAuth.Models;

namespace JWTAuth.Repository.BookingDetails
{
    public interface IPassangerDetailsService
    {
         Task<IEnumerable<PassangerDetail>> GetPassangerDetails();
         Task<PassangerDetail> GetPassangerDetail(int id);
         Task<PassangerDetail> PutPassangerDetail(int id, PassangerDetail passangerDetail);
         Task<PassangerDetail> PostPassangerDetail(PassangerDetail passangerDetail);
        Task<string> DeletePassangerDetail(int id);
    }
}
