using Activities.Mini.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Activities.Mini.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MiniEntityFrameworkCoreModule),
    typeof(MiniApplicationContractsModule)
    )]
public class MiniDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
