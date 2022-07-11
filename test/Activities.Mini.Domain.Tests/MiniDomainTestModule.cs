using Activities.Mini.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Activities.Mini;

[DependsOn(
    typeof(MiniEntityFrameworkCoreTestModule)
    )]
public class MiniDomainTestModule : AbpModule
{

}
