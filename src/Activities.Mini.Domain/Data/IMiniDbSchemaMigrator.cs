using System.Threading.Tasks;

namespace Activities.Mini.Data;

public interface IMiniDbSchemaMigrator
{
    Task MigrateAsync();
}
