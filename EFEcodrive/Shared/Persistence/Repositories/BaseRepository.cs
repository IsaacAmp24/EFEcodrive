using EFEcodrive.Shared.Persistence.Contexts;

namespace EFEcodrive.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}