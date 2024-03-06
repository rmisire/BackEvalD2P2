using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BackEvalD2P2.DAL;

public class BackEvalD2P2DbContextFactory : IDesignTimeDbContextFactory<BackEvalD2P2DbContext>
{
    public BackEvalD2P2DbContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory();
        var configurationPath = Directory.GetCurrentDirectory();

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(configurationPath)
            .AddJsonFile("appsettings.Development.json")
            .Build();
        
        var optionsBuilder = new DbContextOptionsBuilder<BackEvalD2P2DbContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

        return new BackEvalD2P2DbContext(optionsBuilder.Options);
    }
}