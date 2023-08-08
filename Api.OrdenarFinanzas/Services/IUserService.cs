using Api.OrdenarFinanzas.Data.Models;

namespace Api.OrdenarFinanzas.Services
{
    public interface IUserService
    {
        Task<User>? GetUserAsync(string username, string password);
    }

}
