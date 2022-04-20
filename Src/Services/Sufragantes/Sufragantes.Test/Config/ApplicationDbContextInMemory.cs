using Microsoft.EntityFrameworkCore;
using Sufragantes.Persistence.Database;

namespace Sufragantes.Tests.Config
{
    public class ApplicationDbContextInMemory
    {
        public static ApplicationDbContext Get()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: $"E_Voto.Db")
                .Options;

            return new ApplicationDbContext(options);
        }
    }
}
