public class AracMuayene
{
    public int Id { get; set; }
    public string Plate { get; set; } // Hangi araca ait?
    public DateTime InspectionDate { get; set; } // Muayene Tarihi
    public int KilometerAtInspection { get; set; } // O tarihteki KM
    public string InspectionStation { get; set; } // Muayene İstasyonu
}

