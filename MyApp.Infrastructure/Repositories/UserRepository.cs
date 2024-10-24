using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data;

namespace MyApp.Infrastructure.Repositories{

    public class UserRepository(MyAppDbContext context) : GenericRepository<User>(context){
    }
}