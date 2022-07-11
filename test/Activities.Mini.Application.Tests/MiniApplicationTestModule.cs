using Volo.Abp.Modularity;

namespace Activities.Mini;

[DependsOn(
    typeof(MiniApplicationModule),
    typeof(MiniDomainTestModule)
    )]
public class MiniApplicationTestModule : AbpModule
{

}
