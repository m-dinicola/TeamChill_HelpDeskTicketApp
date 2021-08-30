using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamChill_HelpDeskTicketSystem.Models;


namespace TeamChill_HelpDeskTicketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly HelpDeskDBContext _context;
        public BookmarkController(HelpDeskDBContext context)
        {
            _context = context;
        }


        #region Create
        //POST: api/Bookmark/{userEmail}
        //writes a bookmark

        [HttpPost("{userEmail}")]
        public async Task<ActionResult<Bookmark>> AddBookmark(string userEmail, int ticket)
        {
            Bookmark bookmark = new Bookmark
            {
                TicketId = ticket,
                UserEmail = userEmail
            };
            if (await _context.Hdtickets.FindAsync(ticket) is null)
            {
                return BadRequest($"No such ticket found.");
            }

            if (_context.Bookmarks.Count() == 0 || _context.Bookmarks.Where(x => x.UserEmail == userEmail && x.TicketId == ticket).Count() == 0)
            {
                _context.Bookmarks.Add(bookmark);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(HdticketController.GetHdticket), new { TicketID = ticket }, bookmark);
            }

            return Ok("Bookmark already exists");
        }

        #endregion

        #region Read
        //GET: api/Bookmark/{UserEmail}

        [HttpGet("{userEmail}")]
        public List<Hdticket> GetBookmarkedTickets(string userEmail) 
        {
            return _context.Bookmarks.Where(x => x.UserEmail.ToLower() == userEmail.ToLower()).Select(y=>y.Ticket).ToList();
        }

        #endregion

        #region Update
        //PATCH: api/Bookmark/{userEmail}/{ticket}
        //toggles bookmark
        //Decided not to use this method since toggling like this does not
        //use an idempotent method and could lead to a fragile API
        //while our solution is not totally idempotent (POST and DELETE), it's better than a toggle.

        #endregion

        #region Delete
        //DELETE: api/Bookmark/{userEmail}/{ticket}

        [HttpDelete("{userEmail}/{ticket}")]
        public async Task<ActionResult> DeleteBookmark(string userEmail, int ticket)
        {
            List<Bookmark> toBeDeleted = FindBookmark(userEmail, ticket);
            if (toBeDeleted.Count > 0)
            {
                foreach (Bookmark b in toBeDeleted)
                {
                    _context.Bookmarks.Remove(b);
                }
                await _context.SaveChangesAsync();
                return NoContent();
            }
            return NotFound();
        }

        #endregion


        public List<Bookmark> FindBookmark(string userEmail, int ticket)
        {
            return _context.Bookmarks.Where(x => x.TicketId == ticket && x.UserEmail == userEmail).ToList();
        }
    }
}
