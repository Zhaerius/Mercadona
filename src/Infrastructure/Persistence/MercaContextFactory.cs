using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence
{
    public class MercaContextFactory : IDesignTimeDbContextFactory<MercaDbContext>
    {
        public MercaDbContext CreateDbContext(string[] args)
        {
            //Ajout et exploitation d'un settings.json dédié à ce projet
            IConfigurationRoot configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Persistence/dbsettings.json")
                .Build();    

            var optionsBuilder = new DbContextOptionsBuilder<MercaDbContext>();
            optionsBuilder.UseNpgsql(configurationRoot.GetConnectionString("MercaDataBase"));
            return new MercaDbContext(optionsBuilder.Options);
        }
    }
}
