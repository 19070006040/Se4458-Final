using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtelRezervasyonAPI.Entities;


namespace OtelRezervasyon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervasyonController : ControllerBase
    {
        private static List<Rezervasyon> rezervasyonlar = new List<Rezervasyon>();

        [HttpGet]
        public ActionResult<IEnumerable<Rezervasyon>> GetRezervasyonlar()
        {
            return Ok(rezervasyonlar);
        }

        [HttpGet("{id}")]
        public ActionResult<Rezervasyon> GetRezervasyon(int id)
        {
            var rezervasyon = rezervasyonlar.FirstOrDefault(r => r.RezervasyonId == id);
            if (rezervasyon == null)
            {
                return NotFound();
            }
            return Ok(rezervasyon);
        }

        [HttpPost]
        public ActionResult<Rezervasyon> CreateRezervasyon(Rezervasyon rezervasyon)
        {
            rezervasyonlar.Add(rezervasyon);
            return CreatedAtAction(nameof(GetRezervasyon), new { id = rezervasyon.RezervasyonId }, rezervasyon);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateRezervasyon(int id, Rezervasyon updatedRezervasyon)
        {
            var rezervasyon = rezervasyonlar.FirstOrDefault(r => r.RezervasyonId == id);
            if (rezervasyon == null)
            {
                return NotFound();
            }

            rezervasyon.MusteriId = updatedRezervasyon.MusteriId;
            rezervasyon.OdaId = updatedRezervasyon.OdaId;
            rezervasyon.RezervasyonTarihi = updatedRezervasyon.RezervasyonTarihi;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRezervasyon(int id)
        {
            var rezervasyon = rezervasyonlar.FirstOrDefault(r => r.RezervasyonId == id);
            if (rezervasyon == null)
            {
                return NotFound();
            }

            rezervasyonlar.Remove(rezervasyon);
            return NoContent();
        }
    }
}