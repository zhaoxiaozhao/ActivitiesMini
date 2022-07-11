using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Activities.Mini.Data;

/* This is used if database provider does't define
 * IMiniDbSchemaMigrator implementation.
 */
public class NullMiniDbSchemaMigrator : IMiniDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
