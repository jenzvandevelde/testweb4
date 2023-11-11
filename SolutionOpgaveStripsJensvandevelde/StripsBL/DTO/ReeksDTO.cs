using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.DTOs
{
    public class ReeksDTO
    {
        public ReeksDTO(int id, string name, string url, List<StripDTO> strips)
        {
            Id = id;
            Name = name;
            this.url = url;
            this.strips = strips;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string url { get; set; }
        public List<StripDTO> strips { get; set; }



    }
}
