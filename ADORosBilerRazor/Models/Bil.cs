namespace ADORosBilerRazor.Models
{
    public class Bil
    {
        public int Id { get; set; }
        public string Nummerplade { get; set; }
        public string Model { get; set; }
        public int PrisPrDag { get; set; }

        public Bil(int id, string nummerplade, string model, int prisPrDag)
        {
            Id = id;
            Nummerplade = nummerplade;
            Model = model;
            PrisPrDag = prisPrDag;
        }

        public Bil()
        {
        }
        public override string ToString()
        {
            return $"[Bil {Id}] {Nummerplade} ({Model}), koster {PrisPrDag} kr./dag";
        }
    }
}
