using JWTAuth.Models;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;

namespace JWTAuth.Repository.BookingDetails
{
    public class TrainDetailsService : ITrainDetailsService
    {

        public TrainTicketBookingContext _context;
        public TrainDetailsService(TrainTicketBookingContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TrainDetail>> GetTrainDetails()
        {
            var students = await _context.TrainDetails.ToListAsync();
            return students;
        }

        public async Task<TrainDetail> GetTrainDetail(int id)
        {
            var td = await _context.TrainDetails.FirstOrDefaultAsync(x => x.TrainId == id);

            if (td is null)
            {
                return null;
            }
            return td;

        }
        public async Task<TrainDetail> PutTrainDetail(int id, TrainDetail trainDetail)
        {
            var td = await _context.TrainDetails.FirstOrDefaultAsync(x => x.TrainId == id);
            td.TrainName = trainDetail.TrainName;
            td.Sources = trainDetail.Sources;
            td.Distination = trainDetail.Distination;
            await _context.SaveChangesAsync();
            return td;
        }

        public async Task<TrainDetail> PostTrainDetail(TrainDetail trainDetail)
        {
            await _context.TrainDetails.AddAsync(trainDetail);
            _context.SaveChangesAsync();
            return trainDetail;
        }

        public async Task<string> DeleteTrainDetail(int id)
        {
            var dep = await _context.TrainDetails.FirstOrDefaultAsync(x => x.TrainId== id);
            _context.Remove(dep);
            _context.SaveChanges();

            return "Deleted successfully";
        }
        }
}
