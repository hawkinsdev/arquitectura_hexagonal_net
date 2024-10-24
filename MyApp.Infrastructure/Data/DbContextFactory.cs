using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyApp.Infrastructure.Data{
    public class MyAppDbContextFactory : IDesignTimeDbContextFactory<MyAppDbContext>{
        public MyAppDbContext createDbContext(){
            var optionsBuilder = new DbContextOptionsBuilder<MyAppDbContext>();
            optionsBuilder.UseMySql("Server=localhost;Database=vitalbaq;User=root;Password=123123;", 
                new MySqlServerVersion(new Version(8, 0, 21)));

            return new MyAppDbContext(optionsBuilder.Options);
        }

        public MyAppDbContext CreateDbContext(string[] args)
        {
            throw new NotImplementedException();
        }
    }
}