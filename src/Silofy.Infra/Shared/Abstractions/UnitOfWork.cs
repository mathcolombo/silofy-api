using Microsoft.EntityFrameworkCore.Storage;
using Silofy.Domain.Shared.Abstractions.Interfaces;
using Silofy.Infra.Configs.Contexts;

namespace Silofy.Infra.Shared.Abstractions;

public class UnitOfWork(SilofyDbContext context) : IUnitOfWork
{
    private IDbContextTransaction? _transaction;
    
    public async Task BeginTransactionAsync() => _transaction = await context.Database.BeginTransactionAsync();
    
    public async Task CommitAsync()
    {
        try
        {
            await context.SaveChangesAsync();
            await _transaction!.CommitAsync();
        }
        catch (Exception)
        {
            await _transaction!.RollbackAsync();
            throw;
        }
        finally
        {
            await _transaction!.DisposeAsync();
        }
    }
    
    public async Task RollbackAsync() => await _transaction?.RollbackAsync()!;
    
    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
   
}