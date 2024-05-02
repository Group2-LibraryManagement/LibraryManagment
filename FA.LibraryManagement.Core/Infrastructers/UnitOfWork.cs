using FA.LibraryManagement.Core.Context;
using FA.LibraryManagement.Core.IRepositories;
using FA.LibraryManagement.Core.Repositories;

namespace FA.LibraryManagement.Core.Infrastructers;

/// <summary>
///     The unit of work class
/// </summary>
/// <seealso cref="IUnitOfWork" />
public class UnitOfWork : IUnitOfWork
{
    /// <summary>
    /// The user repository
    /// </summary>
    private IUserRepository _userRepository;

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitOfWork" /> class
    /// </summary>
    public UnitOfWork()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="UnitOfWork" /> class
    /// </summary>
    /// <param name="context">The context</param>
    public UnitOfWork(LibraryManagementContext context)
    {
        AppDbContext = context;
    }

    /// <summary>
    /// Gets the value of the user repository
    /// </summary>
    public virtual IUserRepository UserRepository => _userRepository ??= new UserRepository(AppDbContext);

    /// <summary>
    ///     Gets the value of the app db context
    /// </summary>
    public LibraryManagementContext AppDbContext { get; }

    /// <summary>
    ///     Disposes this instance
    /// </summary>
    public void Dispose()
    {
        AppDbContext.Dispose();
    }

    /// <summary>
    ///     Saves the changes
    /// </summary>
    /// <returns>The int</returns>
    public virtual int SaveChanges()
    {
        return AppDbContext.SaveChanges();
    }
}