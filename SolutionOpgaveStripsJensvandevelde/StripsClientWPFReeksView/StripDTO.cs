using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsClientWPFReeksView
{
    public class StripDTO
    {
        public StripDTO(int nr, string name)
        {
            this.nr = nr;
            Name = name;
        }

        public int nr { get; set; }
        public string Name { get; set; }

        /*public string DisplayNr { get; set; }
        public string Title { get; set; }*/


    }
}
