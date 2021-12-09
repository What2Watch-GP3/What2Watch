﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Interfaces
{
    public interface ITicketDataAccess : IBaseDataAccess<Ticket>
    {
        Task<IEnumerable<Ticket>> GetTicketsByShowIdAsync(int showId);

    }
}
