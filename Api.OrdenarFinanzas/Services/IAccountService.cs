using Api.OrdenarFinanzas.Data.Models;

namespace Api.OrdenarFinanzas.Services
{
    public interface IAccountService
    {
        string GenerateJwtToken(User user);
    }

}
