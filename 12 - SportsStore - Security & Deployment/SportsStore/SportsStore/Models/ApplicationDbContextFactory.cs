using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace SportsStore.Models
{
    // [TODO] purpose of this database context factory?
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            return Program.BuildWebHost(args).Services
                .GetRequiredService<ApplicationDbContext>();
        }
    }
}