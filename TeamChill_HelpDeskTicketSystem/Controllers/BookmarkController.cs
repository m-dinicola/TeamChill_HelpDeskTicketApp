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
        //POST: api/Bookmark/{userEmail}/{ticket}
        //writes a bookmark

        [HttpPost]
        public async Task<ActionResult<Bookmark>> AddBookmark()

        #endregion

        #region Read
        //GET: api/Bookmark/{UserEmail}

        [HttpGet("{userEmail}")]
        public List<Hdticket> GetBookmarkedTickets(string userEmail) 
        {
            IEnumerable<int> tickets = _context.Bookmarks.Where(x => x.UserEmail.ToLower() == userEmail.ToLower()).Select(y=>y.TicketId);
            return _context.Hdtickets.Where(x => tickets.Contains(x.TicketId)).ToList();
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

        #endregion

    }
}
