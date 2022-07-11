using Activities.Mini.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Activities.Mini.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MiniController : AbpControllerBase
{
    protected MiniController()
    {
        LocalizationResource = typeof(MiniResource);
    }
}
