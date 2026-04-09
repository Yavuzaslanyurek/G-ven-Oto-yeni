namespace GuvenOto.Models
{
    public class Sehir
    {
        public int Id { get; set; }
        public string Name { get; set; } // Örn: İstanbul, Samsun

        // Hangi bölgeye bağlı olduğunu belirtiyoruz
        public int RegionId { get; set; }
        public Bolge Bolge { get; set; }

        // Bir ilin birden fazla ilçesi olur (Navigation Property)
        public List<Ilce> Ilceler { get; set; } = new List<Ilce>();
    }
}

