using Api.OrdenarFinanzas.Data.Enumerations;

namespace Api.OrdenarFinanzas.Data
{
    public class SeedDb
    {
        private readonly ApiOrdenarFinanzasDBContext context;
        private readonly Random random;

        public SeedDb(ApiOrdenarFinanzasDBContext context)
        {
            this.context = context;
            this.random = new Random();
        }
        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Clients.Any())
            {
                this.AddClient("Cliente Uno","Apellido1", "Apellido2","001","email1@pruebas.com");
                this.AddClient("Cliente Dos", "Apellido1", "Apellido2", "002", "email2@pruebas.com");
                this.AddClient("Cliente Tres", "+", "Apellido2", "003", "email3@pruebas.com");
                await this.context.SaveChangesAsync();
            }

            if (!this.context.UserRoles.Any())
            {
                this.AddUserRole("Administrator", RoleType.SuperAdmin);
                this.AddUserRole("Staff", RoleType.Staff);
                this.AddUserRole("Guest", RoleType.Guest);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Users.Any())
            {
                this.AddUser("AdminUser", "123", 1);
                this.AddUser("StaffUser", "123", 2);
                this.AddUser("GuestUser", "123", 3);
                await this.context.SaveChangesAsync();
            }
        }


        private void AddClient(string nombresCliente,
            string apellido1Cliente,
            string apellido2Cliente,
            string telContactoCliente,
            string emailCliente
            )
        {
            this.context.Clients.Add(new Models.Client
            {
                NombresCliente = nombresCliente,
                Apellido1Cliente = apellido1Cliente,
                Apellido2Cliente = apellido2Cliente,
                EmailCliente = emailCliente,
                TelContactoCliente = telContactoCliente,
                NroDocCliente = this.random.Next(1000000, 1999999).ToString()
            });
        }
        private void AddUserRole(string roleName, RoleType roleType)
        {
            this.context.UserRoles.Add(new Models.UserRole
            {
                Name = roleName,
                Type = roleType
            });
        }
        private void AddUser(string userId, string password, long userRoleId)
        {
            this.context.Users.Add(new Models.User
            {
                UserName = userId,
                Password = password,
                RoleId = userRoleId
            });
        }
    }
}
