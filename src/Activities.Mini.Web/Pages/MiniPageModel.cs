using Activities.Mini.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Activities.Mini.Web.Pages;

public abstract class MiniPageModel : AbpPageModel
{
    protected MiniPageModel()
    {
        LocalizationResourceType = typeof(MiniResource);
    }
}
