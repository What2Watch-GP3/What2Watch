﻿using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ICinemaDataAccess:IBaseDataAccess<Cinema>
    {

        
        Task<IEnumerable<Cinema>> GetListByMovieIdAsync(int movieId);
    }
}
