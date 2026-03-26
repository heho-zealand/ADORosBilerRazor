namespace ADORosBilerRazor.Models
{
    public class Kunde
    {
        public int Id { get; set; }
        public string Navn { get; }
        public int Telefon { get; set; }
        public bool VIP { get; set; }

        public Kunde(int id, string navn, int telefon, bool vip)
        {
            Id = id;
            Navn = navn;
            Telefon = telefon;
            VIP = vip;
        }

        public override string ToString()
        {
            return $"[Kunde {Id}] {Navn} (tlf: {Telefon}), er {(VIP ? "" : "ikke ")}VIP ";
        }
    }
}
