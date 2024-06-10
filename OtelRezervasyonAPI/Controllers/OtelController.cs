using Microsoft.AspNetCore.Mvc;
using OtelRezervasyonAPI.Entities;

namespace OtelRezervasyonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OtelController : ControllerBase
    {
        private static List<Otel> oteller = new List<Otel>();

        [HttpGet]
        public ActionResult<IEnumerable<Otel>> GetOteller()
        {
            return Ok(oteller);
        }

        [HttpGet("{id}")]
        public ActionResult<Otel> GetOtel(int id)
        {
            var otel = oteller.FirstOrDefault(o => o.OtelId == id);
            if (otel == null)
            {
                return NotFound();
            }
            return Ok(otel);
        }

        [HttpPost]
        public ActionResult<Otel> CreateOtel(Otel otel)
        {
            oteller.Add(otel);
            return CreatedAtAction(nameof(GetOtel), new { id = otel.OtelId }, otel);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOtel(int id, Otel updatedOtel)
        {
            var otel = oteller.FirstOrDefault(o => o.OtelId == id);
            if (otel == null)
            {
                return NotFound();
            }

            otel.OtelAdı = updatedOtel.OtelAdı;
            otel.OdaSayısı = updatedOtel.OdaSayısı;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOtel(int id)
        {
            var otel = oteller.FirstOrDefault(o => o.OtelId == id);
            if (otel == null)
            {
                return NotFound();
            }

            oteller.Remove(otel);
            return NoContent();
        }
    }
}
