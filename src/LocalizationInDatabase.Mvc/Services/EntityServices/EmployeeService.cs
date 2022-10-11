using LocalizationInDatabase.Mvc.Data;
using LocalizationInDatabase.Mvc.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace LocalizationInDatabase.Mvc.Services.EntityServices;

public class EmployeeService : IEmployeeService
{
    private readonly ApplicationDbContext _db;

    public EmployeeService(ApplicationDbContext db)
    {
        _db = db;
    }

    #region Create
    public async Task<int> AddAsync(Employee entity, CancellationToken cancellationToken = default)
    {
        await _db.AddAsync(entity, cancellationToken);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<int> AddRangeAsync(ICollection<Employee> entities, CancellationToken cancellationToken = default)
    {
        await _db.AddRangeAsync(entities, cancellationToken);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }
    #endregion

    #region Read
    public async Task<Employee?> GetAsync(Expression<Func<Employee, bool>> predicate,
        Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>? include = null,
        bool enableTracking = false,
        bool ignoreQueryFilters = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<Employee> queryable = _db.Employees;

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

    public async Task<List<Employee>?> ListAsync(
        Expression<Func<Employee, bool>>? predicate = null,
        Func<IQueryable<Employee>, IOrderedQueryable<Employee>>? orderBy = null,
        Func<IQueryable<Employee>, IIncludableQueryable<Employee, object>>? include = null,
        bool enableTracking = false,
        bool ignoreQueryFilters = false,
        CancellationToken cancellationToken = default)
    {
        IQueryable<Employee> queryable = _db.Employees;

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
    public async Task<int> UpdateAsync(Employee entity, CancellationToken cancellationToken = default)
    {
        _db.Update(entity);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<int> UpdateRangeAsync(ICollection<Employee> entities, CancellationToken cancellationToken = default)
    {
        _db.UpdateRange(entities);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }
    #endregion

    #region Delete
    public async Task<int> DeleteAsync(Employee entity, CancellationToken cancellationToken = default)
    {
        _db.Remove(entity);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<int> DeleteRangeAsync(ICollection<Employee> entities, CancellationToken cancellationToken = default)
    {
        _db.RemoveRange(entities);
        var result = await _db.SaveChangesAsync(cancellationToken);
        return result;
    }
    #endregion
}
