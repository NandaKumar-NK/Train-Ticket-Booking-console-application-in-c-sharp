using JWTAuth.Models;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuth.Repository.BookingDetails
{
    public interface  ITrainDetailsService
    {
        Task<IEnumerable<TrainDetail>> GetTrainDetails();
        Task<TrainDetail> GetTrainDetail(int id);
        Task<TrainDetail> PutTrainDetail(int id, TrainDetail trainDetail);
        Task<TrainDetail> PostTrainDetail(TrainDetail trainDetail);
        Task<string> DeleteTrainDetail(int id);
        
        }
}
