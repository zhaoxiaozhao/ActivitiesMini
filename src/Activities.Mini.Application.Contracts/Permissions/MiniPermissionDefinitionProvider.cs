using Activities.Mini.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Activities.Mini.Permissions;

public class MiniPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MiniPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MiniPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MiniResource>(name);
    }
}
