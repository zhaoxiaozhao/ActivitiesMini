using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Activities.Mini;

[Dependency(ReplaceServices = true)]
public class MiniBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Mini";
}
