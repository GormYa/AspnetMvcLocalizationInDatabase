using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using LocalizationInDatabase.Mvc.Data;
using LocalizationInDatabase.Mvc.Models.Entities;

namespace LocalizationInDatabase.Mvc.Services.EntityServices;

public class LanguageService : ILanguageService
{
    private readonly ApplicationDbContext _db;

    public LanguageService(ApplicationDbContext db)
    {
        _db = db;
    }

    public Language? GetLanguageByCulture(string culture)
    {
        var language = _db.Languages.FirstOrDefault(x => x.Culture.Equals(culture.ToLower()));

        return language;
    }

    #region Create
    public async Task<int> AddAsync(Language entity, CancellationToken cancellationToken = default)
    {
        await _db.AddAsync(entity, cancellationToken);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<int> AddRangeAsync(ICollection<Language> entities, CancellationToken cancellationToken = default)
    {
        await _db.AddRangeAsync(entities, cancellationToken);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }
    #endregion

    #region Read
    public async Task<Language?> GetAsync(Expression<Func<Language, bool>> predicate,
        Func<IQueryable<Language>, IIncludableQueryable<Language, object>>? include = null,
        bool enableTracking = false,
        bool ignoreQueryFilters = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<Language> queryable = _db.Languages;

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

    public async Task<List<Language>?> ListAsync(
        Expression<Func<Language, bool>>? predicate = null,
        Func<IQueryable<Language>, IOrderedQueryable<Language>>? orderBy = null,
        Func<IQueryable<Language>, IIncludableQueryable<Language, object>>? include = null,
        bool enableTracking = false,
        bool ignoreQueryFilters = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<Language> queryable = _db.Languages;

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
    public async Task<int> UpdateAsync(Language entity, CancellationToken cancellationToken = default)
    {
        _db.Update(entity);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<int> UpdateRangeAsync(ICollection<Language> entities, CancellationToken cancellationToken = default)
    {
        _db.UpdateRange(entities);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }
    #endregion

    #region Delete
    public async Task<int> DeleteAsync(Language entity, CancellationToken cancellationToken = default)
    {
        _db.Remove(entity);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<int> DeleteRangeAsync(ICollection<Language> entities, CancellationToken cancellationToken = default)
    {
        _db.RemoveRange(entities);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }
    #endregion
}
