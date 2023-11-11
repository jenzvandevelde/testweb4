using StripsBL.DTOs;
using StripsBL.Exceptions;
using StripsBL.Interfaces;
using StripsBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Managers
{
    public class StripsManager
    {
        private IStripsRepository stripsRepository;

        public StripsManager(IStripsRepository stripsRepository)
        {
            this.stripsRepository = stripsRepository;
        }

        public Reeks GetReeks(int reeksId)
        {
            return stripsRepository.GetReeks(reeksId);
        }

        public Strip GetStrip(int stripId)
        {
            return stripsRepository.GetStrip(stripId);
        }
    }
}