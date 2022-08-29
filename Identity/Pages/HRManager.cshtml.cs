using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Identity.Pages
{
    [Authorize(Policy = "MustBelongToHR")]
    public class HRManagerModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
