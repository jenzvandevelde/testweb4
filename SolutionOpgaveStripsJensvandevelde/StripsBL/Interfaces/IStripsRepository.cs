﻿using StripsBL.DTOs;
using StripsBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Interfaces
{
    public interface IStripsRepository
    {
        Strip GetStrip(int stripId);
        Reeks GetReeks(int reeksId);
        
    }
}
