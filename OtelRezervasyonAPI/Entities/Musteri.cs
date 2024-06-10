namespace OtelRezervasyonAPI.Entities
{
    public class Musteri
    {
        public int MusteriId { get; set; }
        public string Isim { get; set; }
        public string Soyisim { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public int OdaNo { get; set; }
    }
}
