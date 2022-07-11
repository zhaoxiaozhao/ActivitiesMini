using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Activities.Mini.Web.Pages;

public class IndexModel : MiniPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
