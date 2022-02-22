using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prs_server_project.Models;

namespace prs_server_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly PrsDbContext _context;

        public RequestsController(PrsDbContext context)
        {
            _context = context;
        }

        // Start added code

        //// RecalcualteRequestTotal(requestId) method
        //// PUT: api/Requests/Recalc/5
        //[HttpPut("recalc/{requestId}")]
        //public async Task<IActionResult> RecalculateRequest(int requestId) {
        //    var request = await _context.Requests
        //                                .Include(x => x.RequestLines)
        //                                .SingleOrDefaultAsync(x => x.Id == requestId);

        //    var sum = request.RequestLines.Sum(x => x.Quantity * x.Price);

        //    request.Total = sum;

        //    await _context.SaveChangesAsync();

        //    return NoContent(); // These lines are from SalesWebApiSolution OrdersController
        //}
        //// Also see recalculate request total method in PRSLibrarySolution RequestlinesController

        //// Review(request) method
        //// PUT: api/Requests/5/Review
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRequestReview(int id, Request request) {
        //    if (request.Total <= 50) {
        //        request.Status = "APPROVED";
        //    } else {
        //        request.Status = "REVIEW";
        //    }

        //    _context.Entry(request).State = EntityState.Modified;

        //    try {
        //        await _context.SaveChangesAsync();
        //    } catch (DbUpdateConcurrencyException) {
        //        if (!RequestExists(id)) {
        //            return NotFound();
        //        } else {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// Approve(request) method
        //// PUT: api/Requests/5/Approve
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRequestApprove(int id, Request request) {

        //    request.Status = "APPROVED";

        //    _context.Entry(request).State = EntityState.Modified;

        //    try {
        //        await _context.SaveChangesAsync();
        //    } catch (DbUpdateConcurrencyException) {
        //        if (!RequestExists(id)) {
        //            return NotFound();
        //        } else {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// Reject(request) method
        //// PUT: api/Requests/5/Reject
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRequestReject(int id, Request request) {

        //    request.Status = "REJECTED";

        //    _context.Entry(request).State = EntityState.Modified;

        //    try {
        //        await _context.SaveChangesAsync();
        //    } catch (DbUpdateConcurrencyException) {
        //        if (!RequestExists(id)) {
        //            return NotFound();
        //        } else {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// GetReviews(userId) method
        //// GET: api/Requests/Review/{userId}
        //public IEnumerable<Request> GetRequestsInReview(int userId) {
        //    var requests = _context.Requests
        //                                .Where(x => x.Status == "REVIEW"
        //                                        && x.UserId != userId)
        //                                .ToList();
        //    return requests; // These lines are from PRSLibrarySolution RequestsController
        //}

        // End added code

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
        {
            return await _context.Requests.ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Request>> GetRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // PUT: api/Requests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequest(int id, Request request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Requests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Request>> PostRequest(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequest", new { id = request.Id }, request);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequest(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestExists(int id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
