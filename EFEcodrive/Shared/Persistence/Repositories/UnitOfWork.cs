using EFEcodrive.Shared.Domain.Repositories;
using EFEcodrive.Shared.Persistence.Contexts;


namespace EFEcodrive.Shared.Persistence.Repositories;

public class UnitOfWork :IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}