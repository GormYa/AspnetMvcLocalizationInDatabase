using LocalizationInDatabase.Mvc.Models.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LocalizationInDatabase.Mvc.Services.EntityServices;

public interface IStringResourceService
{
    #region Create
    Task<int> AddAsync(StringResource entity, CancellationToken cancellationToken = default);

    Task<int> AddRangeAsync(ICollection<StringResource> entities, CancellationToken cancellationToken = default);
    #endregion

    #region Read
    Task<StringResource?> GetAsync(Expression<Func<StringResource, bool>> predicate,
        Func<IQueryable<StringResource>, IIncludableQueryable<StringResource, object>>? include = null,
        bool enableTracking = false,
        bool ignoreQueryFilters = false,
        CancellationToken cancellationToken = default);

    Task<List<StringResource>?> ListAsync(Expression<Func<StringResource, bool>>? predicate = null,
        Func<IQueryable<StringResource>, IOrderedQueryable<StringResource>>? orderBy = null,
        Func<IQueryable<StringResource>, IIncludableQueryable<StringResource, object>>? include = null,
        bool enableTracking = false,
        bool ignoreQueryFilters = false,
        CancellationToken cancellationToken = default);
    #endregion

    #region Update
    Task<int> UpdateAsync(StringResource entity, CancellationToken cancellationToken = default);

    Task<int> UpdateRangeAsync(ICollection<StringResource> entities, CancellationToken cancellationToken = default);
    #endregion

    #region Delete
    Task<int> DeleteAsync(StringResource entity, CancellationToken cancellationToken = default);

    Task<int> DeleteRangeAsync(ICollection<StringResource> entities, CancellationToken cancellationToken = default);
    #endregion
}
