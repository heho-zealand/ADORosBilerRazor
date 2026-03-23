using ADORosBilerRazor.Models;
using ADORosBilerRazor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ADORosBilerRazor.Pages.Biler
{
    public class OpretNyBilModel : PageModel
    {
        UIServiceBiler _uiServiceBiler;

        public OpretNyBilModel(UIServiceBiler uiServiceBiler)
        {
            _uiServiceBiler = uiServiceBiler;
        }

        [BindProperty]
        public Bil NyBil { get; set; } = new Bil();

        
       
        public IActionResult OnPost()
        {
            // Tjek om det indtastede data er validt
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Send data videre til repository
            _uiServiceBiler.Create(NyBil);

            // Vend tilbage til oversigen
            return RedirectToPage("VisAlleBiler");
        }
    }
}
