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
    public class SeatsController : ControllerBase
    {
        private readonly ISeatService _context;

        public SeatsController(ISeatService context)
        {
            _context = context;
        }

        // GET: api/Seats
        [HttpGet]
        public async Task<IEnumerable<Seat>> GetSeats()
        {
          
            return await _context.GetSeats();
        }

        // GET: api/Seats/5
        [HttpGet("{id}")]
        public async Task<Seat> GetSeat(int id)
        {
          

            return await _context.GetSeat(id);
        }

        // PUT: api/Seats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
       // [Authorize]
        public async Task<Seat> PutSeat(int id, Seat seat)
        {
            return await _context.PutSeat(id, seat);
        }

        // POST: api/Seats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //[Authorize]
        public async Task<Seat> PostSeat(Seat seat)
        {
          return await _context.PostSeat(seat);
        }

        // DELETE: api/Seats/5
        [HttpDelete("{id}")]
       // [Authorize]
        public async Task<String> DeleteSeat(int id)
        {
            

            return await _context.DeleteSeat(id);
        }

       
    }
}
