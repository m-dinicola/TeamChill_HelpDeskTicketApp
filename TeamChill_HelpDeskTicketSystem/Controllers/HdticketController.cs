﻿using Microsoft.AspNetCore.Http;
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
    public class HdticketController : ControllerBase
    {
        private readonly HelpDeskDBContext _context;

        public HdticketController(HelpDeskDBContext context)
        {
            _context = context;
        }

        #region Create

        #endregion

        #region Read
        //GET: api/HDTicket


        #endregion

        #region Update

        #endregion

        #region Delete

        #endregion

    }
}
