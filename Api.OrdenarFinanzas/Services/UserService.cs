using Api.OrdenarFinanzas.Data;
using Api.OrdenarFinanzas.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.OrdenarFinanzas.Services
{
    public class UserService : IUserService
    {

        private readonly ApiOrdenarFinanzasDBContext _context;


        public UserService(ApiOrdenarFinanzasDBContext context)
        {
            _context = context;
        }

        public async Task<User>? GetUserAsync(string username, string password)
        {
            if (_context.Users == null)
            {
                return null;
            }
            var user = await _context.Users.FirstOrDefaultAsync(user => user.UserName == username && user.Password == password);

            return user;
        }
    }

}
