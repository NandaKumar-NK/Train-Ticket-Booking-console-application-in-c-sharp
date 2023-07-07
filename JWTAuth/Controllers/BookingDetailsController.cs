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
    public class BookingDetailsController : ControllerBase
    {
        private readonly IBookingDetailsService _context;

        public BookingDetailsController(IBookingDetailsService context)
        {
            _context = context;
        }

        // GET: api/BookingDetails
        [HttpGet]
           public async Task<List<BookingDetail>> GetBookingDeatils()
            {

                return await _context.GetbookingDetail();
            }

            // GET: api/BookingDetails/5
            [HttpGet("{id}")]
            public async Task<ActionResult<BookingDetail>> GetBookingDetail(int id)
            {


                return await _context.GetbookingDetail(id);
            }

            // PUT: api/BookingDetails/5
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPut("{id}")]
           // [Authorize]
            public async Task<BookingDetail> PutBookingDetail(int id, BookingDetail bookingDetail)
            {


                return await  _context.PutbookingDetail(id,bookingDetail);
            }

            // POST: api/BookingDetails
            // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
            [HttpPost]
            //[Authorize]
            public async Task<BookingDetail> PostBookingDetail(BookingDetail bookingDetail)
            {
                return await _context.PostbookingDetail(bookingDetail);
            }

            // DELETE: api/BookingDetails/5
            [HttpDelete("{id}")]
            //[Authorize]
            public async Task<string> DeletebookingDetail(int id)
            {


                return await _context.DeletebookingDetail(id);
            }


    }
}
