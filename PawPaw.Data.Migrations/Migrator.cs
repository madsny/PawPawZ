using System.Reflection;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;

namespace PawPaw.Data.Migrations
{
    public class Migrator
    {
        private readonly IDataSettings _settings;

        public Migrator(IDataSettings settings)
        {
            _settings = settings;
        }

        public void MigrateToLatest()
        {
            var announcer = new NullAnnouncer();
            var assembly = Assembly.GetExecutingAssembly();
            var migrationContext = new RunnerContext(announcer);
            var options = new ProcessorOptions { PreviewOnly = false, Timeout = 60 };
            var factory = new FluentMigrator.Runner.Processors.SqlServer.SqlServer2008ProcessorFactory();
            var processor = factory.Create(_settings.ConnectionString, announcer, options);
            var runner = new MigrationRunner(assembly, migrationContext, processor);
            runner.MigrateUp(true);
        }
    }
}
