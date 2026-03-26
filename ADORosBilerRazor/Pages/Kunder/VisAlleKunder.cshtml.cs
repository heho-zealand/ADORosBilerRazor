using ADORosBilerRazor.Models;
using ADORosBilerRazor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADORosBilerRazor.Pages.Kunder
{
    public class VisAlleKunderModel : PageModel
    {
        UIServiceKunder _uiServiceKunder;
 
        public List<Kunde> Kunder { get; private set; }

        public VisAlleKunderModel(UIServiceKunder uIServiceKunder)
        {
            _uiServiceKunder = uIServiceKunder;
        }


        public void OnGet()
        {
            Kunder = _uiServiceKunder.GetAllKunder();
        }
    }
}
