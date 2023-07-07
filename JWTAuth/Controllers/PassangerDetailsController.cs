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
    public class PassangerDetailsController : ControllerBase
    {
        private readonly IPassangerDetailsService _context;

        public PassangerDetailsController(IPassangerDetailsService context)
        {
            _context = context;
        }

        // GET: api/PassangerDetails
        [HttpGet]
        public async Task<IEnumerable<PassangerDetail>> GetPassangerDetails()
        {
          return await _context.GetPassangerDetails();
        }

        // GET: api/PassangerDetails/5
        [HttpGet("{id}")]
        public async Task<PassangerDetail> GetPassangerDetail(int id)
        {
          return await _context.GetPassangerDetail(id);
        }

        // PUT: api/PassangerDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
       // [Authorize]
        public async Task<PassangerDetail> PutPassangerDetail(int id, PassangerDetail passangerDetail)
        {
            

            return await _context.PutPassangerDetail(id, passangerDetail);
        }

        // POST: api/PassangerDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
       // [Authorize]
        public async Task<PassangerDetail> PostPassangerDetail(PassangerDetail passangerDetail)
        {
          return await _context.PostPassangerDetail(passangerDetail);
        }

        // DELETE: api/PassangerDetails/5
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<string> DeletePassangerDetail(int id)
        {
            return await _context.DeletePassangerDetail(id);
        }

      
    }
}
