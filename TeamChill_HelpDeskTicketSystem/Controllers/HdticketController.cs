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
    public class HdticketController : ControllerBase
    {
        private readonly HelpDeskDBContext _context;

        public HdticketController(HelpDeskDBContext context)
        {
            _context = context;
        }


        #region Create
        [HttpPost]
        public async Task<ActionResult<Hdticket>> NewTicket(Hdticket ticket)
        {
            _context.Hdtickets.Add(ticket);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHdticket), new { ticketID = ticket.TicketId }, ticket);
        }

        #endregion

        #region Read
        //GET: api/HDTicket
        [HttpGet]
        public async Task<List<Hdticket>> GetHdtickets()
        {
            return await _context.Hdtickets.ToListAsync();
        }


        [HttpGet("{ticketID}")]
        public async Task<ActionResult<Hdticket>> GetHdticket(int ticketID)
        {
            var ticket = await _context.Hdtickets.FindAsync(ticketID);
            if(ticket is null)
            {
                return NotFound();
            }
            else
            {
                return ticket;
            }
        }
        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion

    }
}
