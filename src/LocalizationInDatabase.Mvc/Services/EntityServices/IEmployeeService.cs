using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using LocalizationInDatabase.Mvc.Models.Entities;

namespace LocalizationInDatabase.Mvc.Services.EntityServices;

public interface IEmployeeService
{
    #region Create
    Task<int> AddAsync(Employee entity, CancellationToken cancellationToken = default);

    Task<int> AddRangeAsync(ICollection<Employee> entities, CancellationToken cancellationToken = default);
    #endregion

    #region Read
    Task<Employee?> GetAsync(Expression<Func<Employee, bool>> predicate,
        Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>? include = null,
        bool enableTracking = false,
        bool ignoreQueryFilters = false,
        CancellationToken cancellationToken = default);

    Task<List<Employee>?> ListAsync(Expression<Func<Employee, bool>>? predicate = null,
        Func<IQueryable<Employee>, IOrderedQueryable<Employee>>? orderBy = null,
        Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>? include = null,
        bool enableTracking = false,
        bool ignoreQueryFilters = false,
        CancellationToken cancellationToken = default);
    #endregion

    #region Update
    Task<int> UpdateAsync(Employee entity, CancellationToken cancellationToken = default);

    Task<int> UpdateRangeAsync(ICollection<Employee> entities, CancellationToken cancellationToken = default);
    #endregion

    #region Delete
    Task<int> DeleteAsync(Employee entity, CancellationToken cancellationToken = default);

    Task<int> DeleteRangeAsync(ICollection<Employee> entities, CancellationToken cancellationToken = default);
    #endregion
}
