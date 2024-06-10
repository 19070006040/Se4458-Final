using Microsoft.EntityFrameworkCore;
using OtelRezervasyonAPI.Entities;

namespace OtelRezervasyonAPI.Context
{
    public class OtelRezervasyonContext : DbContext
    {
        public OtelRezervasyonContext(DbContextOptions<OtelRezervasyonContext> options) : base(options)
        {
                
        }
        public DbSet<Musteri> Musteris { get; set; }
        public DbSet<Oda> Odas { get; set; }
        public DbSet<Otel> Otels { get; set; }
        public DbSet<Rezervasyon> Rezervasyons { get; set; }
    }
}
