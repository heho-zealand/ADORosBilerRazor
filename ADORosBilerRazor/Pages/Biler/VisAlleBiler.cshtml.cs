using ADORosBilerRazor.Models;
using ADORosBilerRazor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADORosBilerRazor.Pages.Biler
{
    public class VisAlleBilerModel : PageModel
    {
        UIServiceBiler _uiServiceBiler;
        public List<Bil> Biler { get; private set; }

        public VisAlleBilerModel(UIServiceBiler uiServiceBiler)
        {
            _uiServiceBiler = uiServiceBiler;         
        }

        public void OnGet()
        {
            Biler = _uiServiceBiler.GetAllBiler();
        }
    }
}
