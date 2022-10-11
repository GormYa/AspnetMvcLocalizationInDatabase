using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using LocalizationInDatabase.Mvc.Data;
using LocalizationInDatabase.Mvc.Models.Entities;

namespace LocalizationInDatabase.Mvc.Services.EntityServices;

public class StringResourceService : IStringResourceService
{
    private readonly ApplicationDbContext _db;

    public StringResourceService(ApplicationDbContext db)
    {
        _db = db;
    }

    #region Create
    public async Task<int> AddAsync(StringResource entity, CancellationToken cancellationToken = default)
    {
        await _db.AddAsync(entity, cancellationToken);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<int> AddRangeAsync(ICollection<StringResource> entities, CancellationToken cancellationToken = default)
    {
        await _db.AddRangeAsync(entities, cancellationToken);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }
    #endregion

    #region Read
    public async Task<StringResource?> GetAsync(Expression<Func<StringResource, bool>> predicate,
        Func<IQueryable<StringResource>, IIncludableQueryable<StringResource, object>>? include = null,
        bool enableTracking = false,
        bool ignoreQueryFilters = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<StringResource> queryable = _db.StringResources;

        if (!enableTracking)
        {
            queryable = include == null ? queryable.AsNoTracking() : queryable.AsNoTrackingWithIdentityResolution();
        }

        if (include != null)
        {
            queryable = include(queryable);
        }

        if (ignoreQueryFilters == true)
        {
            queryable = queryable.IgnoreQueryFilters();
        }

        var result = await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        return result;
    }

    public async Task<List<StringResource>?> ListAsync(
        Expression<Func<StringResource, bool>>? predicate = null,
        Func<IQueryable<StringResource>, IOrderedQueryable<StringResource>>? orderBy = null,
        Func<IQueryable<StringResource>, IIncludableQueryable<StringResource, object>>? include = null,
        bool enableTracking = false,
        bool ignoreQueryFilters = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<StringResource> queryable = _db.StringResources;

        if (!enableTracking)
        {
            queryable = include == null ? queryable.AsNoTracking() : queryable.AsNoTrackingWithIdentityResolution();
        }

        if (include != null)
        {
            queryable = include(queryable);
        }

        if (predicate != null)
        {
            queryable = queryable.Where(predicate);
        }

        if (orderBy != null)
        {
            queryable = orderBy(queryable);
        }

        if (ignoreQueryFilters == true)
        {
            queryable = queryable.IgnoreQueryFilters();
        }

        var result = await queryable.ToListAsync(cancellationToken);
        return result;
    }
    #endregion

    #region Update
    public async Task<int> UpdateAsync(StringResource entity, CancellationToken cancellationToken = default)
    {
        _db.Update(entity);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<int> UpdateRangeAsync(ICollection<StringResource> entities, CancellationToken cancellationToken = default)
    {
        _db.UpdateRange(entities);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }
    #endregion

    #region Delete
    public async Task<int> DeleteAsync(StringResource entity, CancellationToken cancellationToken = default)
    {
        _db.Remove(entity);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<int> DeleteRangeAsync(ICollection<StringResource> entities, CancellationToken cancellationToken = default)
    {
        _db.RemoveRange(entities);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }
    #endregion
}
