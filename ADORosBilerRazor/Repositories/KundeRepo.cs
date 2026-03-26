using ADORosBilerRazor.Models;
using ADORosBilerRazor.Services;

namespace ADORosBilerRazor.Repositories
{
    public class KundeRepo
    {
        List<Kunde> _kunder;
        DBServiceKunde _dbServiceKunde;

        public KundeRepo(DBServiceKunde dbServiceKunde)
        {
            _dbServiceKunde = dbServiceKunde;
            _kunder = dbServiceKunde.SelectAllFromDB();
        }

        public List<Kunde> GetAllKunder()
        {
            return _kunder;
        }

        public void AddKunde(Kunde kunde)
        {
            _dbServiceKunde.InsertInToDB(kunde);
            _kunder = _dbServiceKunde.SelectAllFromDB();
        }
    }
}
