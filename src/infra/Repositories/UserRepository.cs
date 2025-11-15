using domain.Entities;
using domain.Interfaces.Repositories;
using domain.Models;

namespace infra.Repositories
{
    public class UserRepository(AppDbContext _context) : BaseRepository<DbUser>(_context), IUserRepository
    {

    }
}