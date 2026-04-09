public class AracHasarKaydi
{
    public int Id { get; set; }
    public string Plate { get; set; } // Hangi araca ait?
    public DateTime DamageDate { get; set; } // Kaza Tarihi
    public string DamageReason { get; set; } // Kaza Nedeni (Çarpma, Dolu, Sel vb.)
    public double Amount { get; set; } // Hasar Tutarı
    public bool IsHeavyDamage { get; set; } // Ağır Hasarlı mı? (Pert)
}
