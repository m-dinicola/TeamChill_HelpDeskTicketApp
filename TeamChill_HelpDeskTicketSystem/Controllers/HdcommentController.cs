using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
        [HttpPost]

        public async Task<ActionResult<Hdcomment>> NewHdcomments(Hdcomment comment)
        {
            if (await _context.Hdtickets.FindAsync(comment.TicketId) is null)
            {
                return BadRequest($"No Such Ticket For Comment {JsonSerializer.Serialize(comment)}");
            }
            _context.Hdcomments.Add(comment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(HdticketController.GetHdticket), new { TicketID = comment.TicketId }, comment);

        }
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
