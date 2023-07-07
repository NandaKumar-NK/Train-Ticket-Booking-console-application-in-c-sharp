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
    public class SeatAllocationsController : ControllerBase
    {
        private readonly ISeatAllocationService _context;

        public SeatAllocationsController(ISeatAllocationService context)
        {
            _context = context;
        }

        // GET: api/SeatAllocations
        [HttpGet]
        public async Task<IEnumerable<SeatAllocation>> GetSeatAllocation()
        {
         
            return await _context.GetSeatAllocation();
        }

        // GET: api/SeatAllocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatAllocation>> GetSeatAllocation(int id)
        {
          

            return await _context.GetSeatAllocation(id);
        }

        // PUT: api/SeatAllocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
       // [Authorize]
        public async Task<SeatAllocation> PutSeatAllocation(int id, SeatAllocation seatAllocation)
        {
           
            return  await _context.PutSeatAllocation(id, seatAllocation);
        }

        // POST: api/SeatAllocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
       // [Authorize]
        public async Task<ActionResult<SeatAllocation>> PostSeatAllocation(SeatAllocation seatAllocation)
        {
          

            return await _context.PostSeatAllocation(seatAllocation);
        }

        // DELETE: api/SeatAllocations/5
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<string> DeleteSeatAllocation(int id)
        {

            return await _context.DeleteSeatAllocation(id);
        }

       
    }
}
