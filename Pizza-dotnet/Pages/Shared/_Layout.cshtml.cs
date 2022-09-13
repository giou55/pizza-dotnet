using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static Pizza_dotnet.Pages.ActiveLink;

namespace Pizza_dotnet.Pages;

public class _Layout : PageModel
{
    public string Message;
    public void OnGet()
    {
        Message = "Hello";
    }
}

