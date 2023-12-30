using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace Orderin.API.Extensions
{
    public static class DbExtensions
    {
        public static WebApplication MigrateDatabase<TContext>(this WebApplication app, Action<TContext, IServiceProvider> seeder) where TContext:DbContext
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation($"Starteed DbMigration: {typeof(TContext).Name}");

                    var retry = Policy.Handle<SqlException>()
                        .WaitAndRetry(
                        retryCount: 5,
                        sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                        onRetry: (exception, span, count) =>
                        {
                            logger.LogError("Retrying because of {exception} {retry}", exception, span);
                        });
                    retry.Execute(() => CallSeeder(seeder, context, services));
                    logger.LogInformation($"Migration Completed: {typeof(TContext).Name}");
                }catch (SqlException ex)
                {
                    logger.LogError(ex, $"An error occurred while migrating db: {typeof(TContext).Name}");
                }
            }

            return app;
        }

        private static void CallSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context,
       IServiceProvider services) where TContext : DbContext
        {
            context.Database.Migrate();
            seeder(context, services);
        }
    }

    
}
