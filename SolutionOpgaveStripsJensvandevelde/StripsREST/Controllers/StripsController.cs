using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StripsBL.DTOs;
using StripsBL.Exceptions;
using StripsBL.Managers;
using StripsBL.Model;

namespace StripsREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripsController : ControllerBase
    {
        private StripsManager stripsManager;
        private string url = "http://localhost:5044/api/Strips/beheer/";

        public StripsController(StripsManager stripsManager)
        {
            this.stripsManager = stripsManager;
        }


        [HttpGet("reeks/{reeksId}")]
        public ActionResult<ReeksDTO> GetReeks(int reeksId)
        {
            try
            {
                Reeks r = stripsManager.GetReeks(reeksId);
                List<StripDTO> stripDTOs = new List<StripDTO>();


                stripDTOs.AddRange(r.Strips.Select((s) =>
                {
                    return new StripDTO((int)s.Nr, s.Titel, url + $"strip/{s.Nr}");
                }));


                ReeksDTO reeksDTO = new ReeksDTO(r.ID, r.Naam, url + $"reeks/{reeksId}", stripDTOs);
                return Ok(reeksDTO);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("strip/{stripId}")]
        public ActionResult<StripDTO> GetStrip(int stripId)
        {
            Strip strip = stripsManager.GetStrip(stripId);
            StripDTO stripDTO = new StripDTO(strip.ID, strip.Titel, url + $"strip/{stripId}");
            return stripDTO;

        }
    }
}
