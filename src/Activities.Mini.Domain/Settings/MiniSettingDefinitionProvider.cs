using Volo.Abp.Settings;

namespace Activities.Mini.Settings;

public class MiniSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MiniSettings.MySetting1));
    }
}
