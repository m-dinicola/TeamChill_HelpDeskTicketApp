using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamChill_HelpDeskTicketSystem.Models;

namespace TeamChill_HelpDeskTicketSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HdcommentController : ControllerBase
    {

        private readonly HelpDeskDBContext _context;
        public HdcommentController(HelpDeskDBContext context)
        {
            _context = context;
        }


        #region Create

        #endregion

        #region Read
        //GET: api/Hdcomment/{ticketID}
        [HttpGet("{ticket}")]
        public async Task<ActionResult<List<Hdcomment>>> GetHDComments(int ticket)
        {
            var thisTicket = await _context.Hdtickets.FindAsync(ticket);
            if (thisTicket is null)
            {
                return NotFound();
            }
            else
            {
                return await _context.Hdcomments.Where(x => x.TicketId == ticket).ToListAsync(); 
            }
        }

        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion

    }
}
