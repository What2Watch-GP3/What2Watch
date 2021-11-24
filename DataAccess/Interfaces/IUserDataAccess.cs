﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
   public interface IUserDataAccess
    {
        Task<int> LoginAsync(User user); 
    }
}
