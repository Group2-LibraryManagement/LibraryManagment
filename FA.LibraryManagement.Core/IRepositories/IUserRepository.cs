using FA.LibraryManagement.Core.Infrastructers;
using FA.LibraryManagement.Core.Models;

namespace FA.LibraryManagement.Core.IRepositories;

/// <summary>

/// The user repository interface

/// </summary>

/// <seealso cref="IBaseRepository{User}"/>

public interface IUserRepository : IBaseRepository<User>
{
    /// <summary>
    /// Adds the user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    public void AddUser(User user);

    /// <summary>
    /// Updates the user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    public void UpdateUser(User user);

    /// <summary>
    /// Deletes the user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    public void DeleteUser(User user);

    /// <summary>
    /// Deletes the user using the specified user id
    /// </summary>
    /// <param name="userId">The user id</param>
    public void DeleteUser(int userId);

    /// <summary>
    /// Finds the user id
    /// </summary>
    /// <param name="userId">The user id</param>
    /// <returns>The user</returns>
    public User Find(int userId);

    /// <summary>
    /// Gets the all users
    /// </summary>
    /// <returns>A list of user</returns>
    public IList<User> GetAllUsers();

    /// <summary>
    /// Gets the paged using the specified skip
    /// </summary>
    /// <param name="skip">The skip</param>
    /// <param name="pageSize">The page size</param>
    /// <param name="searchValue">The search value</param>
    /// <param name="sortColumn">The sort column</param>
    /// <param name="sortColumnDirection">The sort column direction</param>
    /// <returns>A list of category</returns>
    public List<Category> GetPaged(int skip, int pageSize, string? searchValue, string? sortColumn,
        string? sortColumnDirection);

    /// <summary>
    /// Gets the user with role using the specified user id
    /// </summary>
    /// <param name="userId">The user id</param>
    /// <returns>The user</returns>
    User GetUserWithRole(int userId);
    /// <summary>
    /// Detaches the user
    /// </summary>
    /// <param name="user">The user</param>
    public void Detach(User user);
}