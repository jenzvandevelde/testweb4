using StripsBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsClientWPFReeksView
{
    public class ReeksDTO
    {
        public ReeksDTO(int id, string name, List<StripDTO> strips)
        {
            Id = id;
            Name = name;
            this.strips = strips;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StripDTO> strips { get; set; }


    }
}
