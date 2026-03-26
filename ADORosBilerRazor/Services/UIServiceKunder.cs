using ADORosBilerRazor.Models;
using ADORosBilerRazor.Repositories;

namespace ADORosBilerRazor.Services
{
    public class UIServiceKunder
    {
        List<Kunde> _kunder;
        KundeRepo _kundeRepo;

        public UIServiceKunder(KundeRepo kundeRepo)
        {
            _kundeRepo = kundeRepo;
            _kunder = kundeRepo.GetAllKunder();
        }

        public List<Kunde> GetAllKunder()
        {
            return _kunder;
        }

        public void Create(Kunde kunde)
        {
            _kundeRepo.AddKunde(kunde);
            _kunder = _kundeRepo.GetAllKunder();
        }

    }
}
