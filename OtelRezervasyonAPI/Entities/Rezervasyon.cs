namespace OtelRezervasyonAPI.Entities
{
    public class Rezervasyon
    {
        public int RezervasyonId { get; set; }
        public int MusteriId { get; set; }
        public int OdaId { get; set; }
        public DateTime RezervasyonTarihi { get; set; }
    }
}
