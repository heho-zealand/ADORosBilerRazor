using ADORosBilerRazor.Models;

namespace ADORosBilerRazor.Services
{
    public class UIServiceBiler
    {
        List<Bil> _biler;
        DBServiceBil _dbService;

        public UIServiceBiler(DBServiceBil dbService)
        {
            _dbService = dbService;
            _biler = dbService.GetAllCars();
        }

        public List<Bil> GetAllBiler()
        {
            return _biler;
        }

        public void Create(Bil bil)
        {
            _dbService.Create(bil);
            _biler = _dbService.GetAllCars();
        }


    }
}
