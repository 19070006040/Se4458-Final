using Microsoft.AspNetCore.Mvc;
using OtelRezervasyonAPI.Entities;

namespace OtelRezervasyonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OdaController : ControllerBase
    {
        private static List<Oda> odalar = new List<Oda>();

        [HttpGet]
        public ActionResult<IEnumerable<Oda>> GetOdalar()
        {
            return Ok(odalar);
        }

        [HttpGet("{id}")]
        public ActionResult<Oda> GetOda(int id)
        {
            var oda = odalar.FirstOrDefault(o => o.OdaId == id);
            if (oda == null)
            {
                return NotFound();
            }
            return Ok(oda);
        }

        [HttpPost]
        public ActionResult<Oda> CreateOda(Oda oda)
        {
            odalar.Add(oda);
            return CreatedAtAction(nameof(GetOda), new { id = oda.OdaId }, oda);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOda(int id, Oda updatedOda)
        {
            var oda = odalar.FirstOrDefault(o => o.OdaId == id);
            if (oda == null)
            {
                return NotFound();
            }

            oda.OdaTuru = updatedOda.OdaTuru;
            oda.Doluluk = updatedOda.Doluluk;
            oda.OdaNo = updatedOda.OdaNo;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOda(int id)
        {
            var oda = odalar.FirstOrDefault(o => o.OdaId == id);
            if (oda == null)
            {
                return NotFound();
            }

            odalar.Remove(oda);
            return NoContent();
        }
    }
}

