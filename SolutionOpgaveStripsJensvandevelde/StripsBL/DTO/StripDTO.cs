using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.DTOs
{
    public class StripDTO
    {
        public StripDTO(int? nr, string name, string url)
        {
            this.nr = nr;
            Name = name;
            this.url = url;
        }
        public int? nr { get; set; }
        public string Name { get; set; }
        public string url { get; set; }

    }
}
