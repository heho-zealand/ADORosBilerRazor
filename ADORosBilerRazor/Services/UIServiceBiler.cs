using ADORosBilerRazor.Models;
using ADORosBilerRazor.Repositories;

namespace ADORosBilerRazor.Services
{
    public class UIServiceBiler
    {
        List<Bil> _biler;
        BilRepo _bilRepo;

        public UIServiceBiler(BilRepo bilRepo)
        {
            _bilRepo = bilRepo;
            _biler = bilRepo.GetAllBiler();
        }

        public List<Bil> GetAllBiler()
        {
            return _biler;
        }

        public void Create(Bil bil)
        {
            _bilRepo.AddBil(bil);
            _biler = _bilRepo.GetAllBiler();
        }


    }
}
