using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyArt.DataAccess
{
    public class MyArtContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Initial Catalog=MyArt; User Id=sa; Password=<YourStrong!Passw0rd>;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
