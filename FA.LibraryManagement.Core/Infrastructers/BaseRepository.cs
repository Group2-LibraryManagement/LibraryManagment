using System.Linq.Expressions;
using FA.LibraryManagement.Core.Context;
using Microsoft.EntityFrameworkCore;

namespace FA.LibraryManagement.Core.Infrastructers;

/// <summary>
///     The base repository class
/// </summary>
/// <seealso cref="IBaseRepository{TEntity}" />
public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
{
    /// <summary>
    ///     The context
    /// </summary>
    protected readonly LibraryManagementContext Context;

    /// <summary>
    ///     The db set
    /// </summary>
    protected DbSet<TEntity> DbSet;

    /// <summary>
    ///     Initializes a new instance of the <see cref="BaseRepository" /> class
    /// </summary>
    /// <param name="context">The context</param>
    protected BaseRepository(LibraryManagementContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }

    /// <summary>
    ///     Creates the entity
    /// </summary>
    /// <param name="entity">The entity</param>
    public void Create(TEntity entity)
    {
        DbSet.Add(entity);
        //Context.Entry<TEntity>(entity).State = EntityState.Added;
    }

    /// <summary>
    ///     Creates the range using the specified entities
    /// </summary>
    /// <param name="entities">The entities</param>
    public void CreateRange(List<TEntity> entities)
    {
        DbSet.AddRange(entities);
    }

    /// <summary>
    ///     Deletes the entity
    /// </summary>
    /// <param name="entity">The entity</param>
    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
        // Context.Entry<TEntity>(entity).State = EntityState.Deleted;
    }

    /// <summary>
    /// </summary>
    /// <param name="ids"></param>
    /// <exception cref="ArgumentException"></exception>
    public void Delete(params object[] ids)
    {
        var entity = DbSet.Find(ids);
        if (entity == null)
            throw new ArgumentException($"{string.Join(";", ids)} not exist in the {typeof(TEntity).Name} table");
        DbSet.Remove(entity);
    }

    /// <summary>
    ///     Finds the predicate
    /// </summary>
    /// <param name="predicate">The predicate</param>
    /// <returns>An enumerable of t entity</returns>
    public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
    {
        return DbSet.Where(predicate);
    }

    /// <summary>
    /// Gets the all including using the specified include properties
    /// </summary>
    /// <param name="includeProperties">The include properties</param>
    /// <returns>An enumerable of t entity</returns>
    public IEnumerable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> queryable = DbSet;
        return includeProperties.Aggregate(queryable, (current, includeProperty) => current.Include(includeProperty));
    }

    /// <summary>
    ///     Gets the all
    /// </summary>
    /// <returns>The db set</returns>
    public IEnumerable<TEntity> GetAll()
    {
        return DbSet;
    }

    /// <summary>
    ///     Gets the by id using the specified primary key
    /// </summary>
    /// <param name="primaryKey">The primary key</param>
    /// <returns>The entity</returns>
    public TEntity GetById(params object[] primaryKey)
    {
        return DbSet.Find(primaryKey);
    }

    /// <summary>
    ///     Updates the entity
    /// </summary>
    /// <param name="entity">The entity</param>
    public void Update(TEntity entity)
    {
        DbSet.Update(entity);
        // Context.Entry<TEntity>(entity).State = EntityState.Modified;
    }

    /// <summary>
    ///     Updates the range using the specified entities
    /// </summary>
    /// <param name="entities">The entities</param>
    public void UpdateRange(List<TEntity> entities)
    {
        DbSet.UpdateRange(entities);
    }

    /// <summary>
    ///     Finds the one using the specified predicate
    /// </summary>
    /// <param name="predicate">The predicate</param>
    /// <returns>The entity</returns>
    public TEntity FindOne(Func<TEntity, bool> predicate)
    {
        return DbSet.FirstOrDefault(predicate);
    }

    /// <summary>
    ///     Gets the paging using the specified order by
    /// </summary>
    /// <param name="orderBy">The order by</param>
    /// <param name="currentPage">The current page</param>
    /// <param name="pageSize">The page size</param>
    /// <param name="filter">The filter</param>
    /// <exception cref="NotImplementedException"></exception>
    /// <returns>An enumerable of t entity</returns>
    public IEnumerable<TEntity> GetPaging(IOrderedEnumerable<TEntity> orderBy, int currentPage = 1, int pageSize = 10,
        string filter = null)
    {
        throw new NotImplementedException();
    }

    //get all include
    /// <summary>
    /// Gets the all including using the specified filter
    /// </summary>
    /// <param name="filter">The filter</param>
    /// <param name="includeProperties">The include properties</param>
    /// <returns>An enumerable of t entity</returns>
    public IEnumerable<TEntity> GetAllIncluding(Expression<Func<TEntity, bool>> filter,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> queryable = DbSet;
        queryable = includeProperties.Aggregate(queryable,
            (current, includeProperty) => current.Include(includeProperty));
        return queryable.Where(filter);
    }
}