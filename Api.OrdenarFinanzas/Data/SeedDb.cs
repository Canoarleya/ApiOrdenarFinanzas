using Api.OrdenarFinanzas.Data.Enumerations;
using Api.OrdenarFinanzas.Data.Models;

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
                this.AddUser("acano", "123", 1);
                this.AddUser("StaffUser", "123", 2);
                this.AddUser("GuestUser", "123", 3);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Periodicidades.Any())
            {
                this.AddPeriodicidad("Diaria");
                this.AddPeriodicidad("Semanal");
                this.AddPeriodicidad("Mensual");
                await this.context.SaveChangesAsync();
            }

            if (!this.context.TiposPago.Any())
            {
                this.AddTipoPago("Metas de Ahorro");
                this.AddTipoPago("Gastos Fijos");
                this.AddTipoPago("Gastos No programados");
                await this.context.SaveChangesAsync();
            }

            if (!this.context.TiposGastosFijos.Any())
            {
                this.AddTipoGastoFijo("Servicios Publicos", 1);
                this.AddTipoGastoFijo("Salud", 1);
                this.AddTipoGastoFijo("Alimentacion", 1);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.GastosFijos.Any())
            {
                this.AddGastoFijo("Gasto Fijo 1", 10000, 1,1);
                this.AddGastoFijo("Gasto Fijo 2", 10000, 1, 1);
                this.AddGastoFijo("Gasto Fijo 3", 10000, 1, 1);
                await this.context.SaveChangesAsync();
            }

            if (!this.context.MetasAhorro.Any())
            {
                this.AddMetaAhorro("Ahorro 1", 10000, 1000,DateTime.Today, 100,1,DateTime.Today.AddYears(1));
                this.AddMetaAhorro("Ahorro 2", 10000, 1000, DateTime.Today, 100, 1, DateTime.Today.AddYears(1));
                this.AddMetaAhorro("Ahorro 3", 10000, 1000, DateTime.Today, 100, 1, DateTime.Today.AddYears(1));
                await this.context.SaveChangesAsync();
            }

            if (!this.context.Pagos.Any())
            {
                this.AddPago("Pago Ahorro 1",DateTime.Today, 1000,1, 1);
                this.AddPago("Pago Ahorro 2", DateTime.Today, 2000, 1, 1);
                this.AddPago("Pago Ahorro 3", DateTime.Today, 30000, 1, 1);
                this.AddPago("Pago Gasto 1", DateTime.Today, 4000, 2, 1);
                this.AddPago("Pago Gasto 2", DateTime.Today, 5000, 2, 1);
                this.AddPago("Pago Gasto 3", DateTime.Today, 6000, 2, 1);
                this.AddPago("Pago No Contemplado 1", DateTime.Today, 7000, 3, 1);
                this.AddPago("Pago No Contemplado 2", DateTime.Today, 8000, 3, 1);
                this.AddPago("Pago No Contemplado 3", DateTime.Today, 9000, 3, 1);

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

        private void AddTipoPago(string TipoPagoDescripcion)
        {
            this.context.TiposPago.Add(new Models.TipoPago
            {
                DescripcionTipoPago = TipoPagoDescripcion
            });
        }


        private void AddPeriodicidad(string DescripcionPeriodicidad)
        {
            this.context.Periodicidades.Add(new Models.Periodicidad
            {
                DescripcionPeriodicidad = DescripcionPeriodicidad
            });
        }

        private void AddTipoGastoFijo(string DescripcionTipoGastoFijo, long UserId)
        {
            this.context.TiposGastosFijos.Add(new Models.TipoGastoFijo
            {
                UserId = UserId,
                DescripcionTipoGastoFijo = DescripcionTipoGastoFijo
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


        private void AddGastoFijo(string descripcionGastoFijo, 
                                  decimal montoEstimado, 
                                   long idPeriodicidad,
                                   long idTipoGastoFijo)
        {
            this.context.GastosFijos.Add(new Models.GastoFijo
            {
                DescripcionGastoFijo = descripcionGastoFijo,
                MontoEstimado = montoEstimado,
                IdPeriodicidad = idPeriodicidad,
                IdTipoGastoFijo = idTipoGastoFijo
            });
        }

        private void AddMetaAhorro(string DescripcionMetaAhorro,
                          decimal MontoObjetivo,
                          decimal BaseInicial,
                           DateTime FechaInicio,
                           decimal MontoPeriodico,
                           long IdPeriodicidad,
                           DateTime FechaProyectadaFin)
        {
            this.context.MetasAhorro.Add(new Models.MetaAhorro
            {
                DescripcionMetaAhorro = DescripcionMetaAhorro,
                MontoObjetivo = MontoObjetivo,
                BaseInicial = BaseInicial,
                FechaInicio = FechaInicio,
                MontoPeriodico = MontoPeriodico,
                IdPeriodicidad = IdPeriodicidad,
                FechaProyectadaFin = FechaProyectadaFin
            });
        }



        private void AddPago(string DescripcionPago,
                          DateTime Fecha,
                           decimal Monto,
                           long IdTipoPago,
                           long IdSubtipo)
        {
            this.context.Pagos.Add(new Models.Pago
            {
                DescripcionPago = DescripcionPago,
                Fecha = Fecha,
                Monto = Monto,
                IdTipoPago = IdTipoPago,
                IdSubtipo = IdSubtipo
            });
        }

    }
}
