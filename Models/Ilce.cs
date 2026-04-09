namespace GuvenOto.Models
{
    public class Ilce
    {
        public int Id { get; set; }
        public string Name { get; set; } // Örn: Kadıköy, İlkadım

        // Hangi ile bağlı olduğunu belirtiyoruz
        public int CityId { get; set; }
        public Sehir Sehir { get; set; }
    }
}

