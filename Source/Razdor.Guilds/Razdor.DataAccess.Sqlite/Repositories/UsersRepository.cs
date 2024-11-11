using Microsoft.EntityFrameworkCore;

using Razdor.Guilds.DataAccess.Core;
using Razdor.Guilds.Entities.Users;

namespace Razdor.DataAccess.EntityFramework.Repositories;

public class UsersRepository : IUserRepository
{
    RazdorDataContext _context;

    public UsersRepository(RazdorDataContext context)
    {
        _context = context;
    }

    public async Task<IUser?> FindByIdAsync(ulong id)
    {
        return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
    }
}