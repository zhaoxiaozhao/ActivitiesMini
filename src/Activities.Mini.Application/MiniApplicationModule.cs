using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.BlobStoring;
using Volo.Abp.BlobStoring.FileSystem;
using Volo.Abp.Caching;
using Volo.Abp.ObjectMapping;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Activities.Mini;

[DependsOn(
    typeof(AbpAutoMapperModule),
    typeof(MiniDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(MiniApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpBlobStoringModule),
    typeof(AbpBlobStoringFileSystemModule)
    )]
public class MiniApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<MiniApplicationModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<MiniApplicationModule>();
        });

        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "activity_";
        });

        Configure<AbpBlobStoringOptions>(options =>
        {
            options.Containers.Configure("profile-pictures", container =>
            {
                container.UseFileSystem(fileSystem =>
                {
                    fileSystem.BasePath = "D:\\my-files";
                });
            });
        });
    }
}
