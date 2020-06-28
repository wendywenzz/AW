using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class MigrationExtensions
    {
        public static IApplicationBuilder UseMigrations(this IApplicationBuilder app, IConfiguration config)
        {
            bool useMigration = Convert.ToBoolean(config.GetSection("ConnectionStrings:EnabledMigrations").Value);
            if (useMigration)
            {
                using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
                {
                    using (var context = serviceScope.ServiceProvider.GetService<StoreContext>())
                    {
                        context.Database.Migrate();
                    }
                }
            };

            return app;
        }
    }
}
