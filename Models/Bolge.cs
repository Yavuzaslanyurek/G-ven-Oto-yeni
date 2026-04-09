namespace GuvenOto.Models
{
    public class Bolge
    {
        public int Id { get; set; }
        public string Name { get; set; } // Örn: Marmara, İç Anadolu

        // Bir bölgenin birden fazla ili olur (Navigation Property)
        public ICollection<Sehir> Sehirler { get; set; } = new List<Sehir>();
    }
}

