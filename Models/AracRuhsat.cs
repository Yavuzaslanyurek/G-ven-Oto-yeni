public class AracRuhsat
{
    public int Id { get; set; }
    public string Plate { get; set; } // Plaka (Eşleşme anahtarı)
    public string EngineNumber { get; set; } // Motor No
    public string ChassisNumber { get; set; } // Şasi No
    public string OwnerName { get; set; } // Ruhsat Sahibi (Gizli tutulabilir)
    public string VehicleColor { get; set; } // Ruhsattaki Renk (İlanla uyum kontrolü için)
    public DateTime RegistrationDate { get; set; } // İlk Tescil Tarihi
}

