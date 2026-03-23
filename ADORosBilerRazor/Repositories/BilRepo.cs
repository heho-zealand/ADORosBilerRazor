using ADORosBilerRazor.Models;
using ADORosBilerRazor.Services;

namespace ADORosBilerRazor.Repositories
{
    public class BilRepo
    {
        List<Bil> _biler;
        DBServiceBil _dbServiceBil;

        public BilRepo(DBServiceBil dbServiceBil)
        {
            _dbServiceBil = dbServiceBil;
            _biler = dbServiceBil.GetAllCars();
        }

        public List<Bil> GetAllBiler()
        {
            return _biler;
        }
    }
}
