using LocalizationInDatabase.Mvc.Models.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LocalizationInDatabase.Mvc.Services.EntityServices;

public interface ILanguageService
{
    Language? GetLanguageByCulture(string culture);

    #region Create
    Task<int> AddAsync(Language entity, CancellationToken cancellationToken = default);

    Task<int> AddRangeAsync(ICollection<Language> entities, CancellationToken cancellationToken = default);
    #endregion

    #region Read
    Task<Language?> GetAsync(Expression<Func<Language, bool>> predicate,
        Func<IQueryable<Language>, IIncludableQueryable<Language, object>>? include = null,
        bool enableTracking = false,
        bool ignoreQueryFilters = false,
        CancellationToken cancellationToken = default);

    Task<List<Language>?> ListAsync(Expression<Func<Language, bool>>? predicate = null,
        Func<IQueryable<Language>, IOrderedQueryable<Language>>? orderBy = null,
        Func<IQueryable<Language>, IIncludableQueryable<Language, object>>? include = null,
        bool enableTracking = false,
        bool ignoreQueryFilters = false,
        CancellationToken cancellationToken = default);
    #endregion

    #region Update
    Task<int> UpdateAsync(Language entity, CancellationToken cancellationToken = default);

    Task<int> UpdateRangeAsync(ICollection<Language> entities, CancellationToken cancellationToken = default);
    #endregion

    #region Delete
    Task<int> DeleteAsync(Language entity, CancellationToken cancellationToken = default);

    Task<int> DeleteRangeAsync(ICollection<Language> entities, CancellationToken cancellationToken = default);
    #endregion
}
