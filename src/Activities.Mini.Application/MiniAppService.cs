using System;
using System.Collections.Generic;
using System.Text;
using Activities.Mini.Localization;
using Volo.Abp.Application.Services;

namespace Activities.Mini;

/* Inherit your application services from this class.
 */
public abstract class MiniAppService : ApplicationService
{
    protected MiniAppService()
    {
        LocalizationResource = typeof(MiniResource);
    }
}
