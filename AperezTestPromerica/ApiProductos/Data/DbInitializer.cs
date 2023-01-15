using Core.Entities;
using Infrastructure.Data;

namespace ApiProductos.Data
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

            _context.Products.AddRange(
                new Product()
                {
                    Id = 1,
                    Name = "ProductoA",
                    RoleId = 1
                },
                new Product()
                {
                    Id = 2,
                    Name = "ProductoB",
                    RoleId = 1
                },
                new Product()
                {
                    Id = 3,
                    Name = "ProductoC",
                    RoleId = 1
                },
                new Product()
                {
                    Id = 4,
                    Name = "ProductoA",
                    RoleId = 2,
                },
                new Product()
                {
                    Id = 5,
                    Name = "ProductoB",
                    RoleId = 3
                });

            _context.SaveChanges();
        }
    }
}
