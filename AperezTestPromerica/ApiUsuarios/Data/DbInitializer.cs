using Core.Entities;
using Infrastructure.Data;

namespace ApiUsuarios.Data
{
    public static class DbInitializer
    {
        public static void AddCustomerData(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var _context = scope.ServiceProvider.GetService<PersistenceContext>();

            _context.Roles.AddRange(
                new Role()
                {
                    Id = 1,
                    Name = "Principal"
                },
                new Role()
                {
                    Id = 2,
                    Name = "Delegado"
                });

            _context.Users.AddRange(
                new User()
                {
                    Id = 1,
                    UserName = "user1",
                    Password = "123456",
                    RoleId = 1
                },
                new User()
                {
                    Id = 2,
                    UserName = "user2",
                    Password = "123456",
                    RoleId = 2
                }
             );

            _context.SaveChanges();
        }
    }
}
