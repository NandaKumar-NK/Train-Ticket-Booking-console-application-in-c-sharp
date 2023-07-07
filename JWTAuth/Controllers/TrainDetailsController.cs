using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JWTAuth.Models;
using JWTAuth.Repository.BookingDetails;
using Microsoft.AspNetCore.Authorization;

namespace JWTAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TrainDetailsController : ControllerBase
    {
        private readonly ITrainDetailsService _context;

        public TrainDetailsController(ITrainDetailsService context)
        {
            _context = context;
        }

        // GET: api/TrainDetails
        [HttpGet]
       
        public async Task<IEnumerable<TrainDetail>> GetTrainDetails()
        {
         
            return await _context.GetTrainDetails();
        }

        // GET: api/TrainDetails/5
        [HttpGet("{id}")]
        
        public async Task<TrainDetail> GetTrainDetail(int id)
        {

            return await _context.GetTrainDetail(id);
        }

        // PUT: api/TrainDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
       // [Authorize]
        public async Task<TrainDetail> PutTrainDetail(int id, TrainDetail trainDetail)
        {
            

            return await _context.PutTrainDetail(id,trainDetail);
        }

        // POST: api/TrainDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //[Authorize]
        public async Task<TrainDetail> PostTrainDetail(TrainDetail trainDetail)
        {
          

            return await _context.PostTrainDetail(trainDetail);
        }

        // DELETE: api/TrainDetails/5
        [HttpDelete("{id}")]
       // [Authorize]
        public async Task<string> DeleteTrainDetail(int id)
        {
            

            return await _context.DeleteTrainDetail(id);
        }

        
    }
}
