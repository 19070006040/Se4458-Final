using Microsoft.AspNetCore.Mvc;
using OtelRezervasyonAPI.Entities;

namespace OtelRezervasyonAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusteriController : ControllerBase
    {
        private static List<Musteri> musteriler = new List<Musteri>();

        [HttpGet]
        public ActionResult<IEnumerable<Musteri>> GetMusteriler()
        {
            return Ok(musteriler);
        }

        [HttpGet("{id}")]
        public ActionResult<Musteri> GetMusteri(int id)
        {
            var musteri = musteriler.FirstOrDefault(m => m.MusteriId == id);
            if (musteri == null)
            {
                return NotFound();
            }
            return Ok(musteri);
        }

        [HttpPost]
        public ActionResult<Musteri> CreateMusteri(Musteri musteri)
        {
            musteriler.Add(musteri);
            return CreatedAtAction(nameof(GetMusteri), new { id = musteri.MusteriId }, musteri);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateMusteri(int id, Musteri updatedMusteri)
        {
            var musteri = musteriler.FirstOrDefault(m => m.MusteriId == id);
            if (musteri == null)
            {
                return NotFound();
            }

            musteri.Isim = updatedMusteri.Isim;
            musteri.Soyisim = updatedMusteri.Soyisim;
            musteri.GirisTarihi = updatedMusteri.GirisTarihi;
            musteri.CikisTarihi = updatedMusteri.CikisTarihi;
            musteri.OdaNo = updatedMusteri.OdaNo;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMusteri(int id)
        {
            var musteri = musteriler.FirstOrDefault(m => m.MusteriId == id);
            if (musteri == null)
            {
                return NotFound();
            }

            musteriler.Remove(musteri);
            return NoContent();
        }
    }
}
