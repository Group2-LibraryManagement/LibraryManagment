using FA.LibraryManagement.Core.Context;
using FA.LibraryManagement.Core.IRepositories;

namespace FA.LibraryManagement.Core.Infrastructers;

/// <summary>
///     The unit of work interface
/// </summary>
/// <seealso cref="IDisposable" />
public interface IUnitOfWork : IDisposable
{
    /// <summary>
    /// Gets the value of the user repository
    /// </summary>
    public IUserRepository UserRepository { get; } // read only

    /// <summary>
    ///     Gets the value of the app db context
    /// </summary>
    public LibraryManagementContext AppDbContext { get; }

    /// <summary>
    ///     Saves the changes
    /// </summary>
    /// <returns>The int</returns>
    int SaveChanges();
}