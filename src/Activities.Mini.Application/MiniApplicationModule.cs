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
using Volo.Abp.BlobStoring.Aliyun;

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
            //options.Containers.Configure("profile-pictures", container =>
            //{
            //    //container.UseFileSystem(fileSystem =>
            //    //{
            //    //    fileSystem.BasePath = "D:\\my-files";
            //    //});
            //});

            options.Containers.ConfigureDefault(container =>
            {
                container.UseAliyun(aliyun =>
                {
                    aliyun.AccessKeyId = "LTAI5tHkL4Ed7Cy4aMszkUDi";
                    aliyun.AccessKeySecret = "5OpQfTGWQa0M7aUTNwTP3MMIpfCHPu";
                    aliyun.Endpoint = "activitybucket01.oss-cn-chengdu.aliyuncs.com";
                    aliyun.RegionId = "cn-chengdu";
                    aliyun.RoleArn = "acs:ram::1765183228334452:role/aliyunossrole";
                    aliyun.RoleSessionName = "the name of the certificate";
                    aliyun.Policy = "{\r\n    \"Statement\": [\r\n        {\r\n            \"Action\": \"oss:*\",\r\n            \"Effect\": \"Allow\",\r\n            \"Resource\": \"*\"\r\n        }\r\n    ],\r\n    \"Version\": \"1\"\r\n}";
                    aliyun.DurationSeconds = 900;
                    aliyun.ContainerName = "activitybucket01";
                    aliyun.CreateContainerIfNotExists = true;
                });
            });
        });
    }
}
