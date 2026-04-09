using System.Collections.Generic;

namespace GuvenOto.Models
{
    public class Marka
    {
        public int Id { get; set; }
        public string Name { get; set; } // Örn: BMW, Fiat, Mercedes

        // Bir markanın birden fazla modeli olabilir
        public List<AracModeli> Models { get; set; } = new List<AracModeli>();
    }
}
