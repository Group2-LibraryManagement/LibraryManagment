using FA.LibraryManagement.Core.Context;
using FA.LibraryManagement.Core.Infrastructers;
using FA.LibraryManagement.Core.IRepositories;
using FA.LibraryManagement.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FA.LibraryManagement.Core.Repositories;

/// <summary>

/// The user repository class

/// </summary>

public class UserRepository(LibraryManagementContext context) : BaseRepository<User>(context), IUserRepository
{
    /// <summary>
    /// Adds the user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    public void AddUser(User user)
    {
        Create(user);
    }

    /// <summary>
    /// Updates the user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    public void UpdateUser(User user)
    {
        Update(user);
    }

    /// <summary>
    /// Deletes the user using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    public void DeleteUser(User user)
    {
        Delete(user);
    }

    /// <summary>
    /// Deletes the user using the specified user id
    /// </summary>
    /// <param name="userId">The user id</param>
    public void DeleteUser(int userId)
    {
        Delete(userId);
    }

    /// <summary>
    /// Finds the user id
    /// </summary>
    /// <param name="userId">The user id</param>
    /// <returns>The user</returns>
    public User Find(int userId)
    {
        return GetById(userId);
    }

    /// <summary>
    /// Gets the all users
    /// </summary>
    /// <returns>A list of user</returns>
    public IList<User> GetAllUsers()
    {
        return GetAll().ToList();
    }

    /// <summary>
    /// Gets the paged using the specified skip
    /// </summary>
    /// <param name="skip">The skip</param>
    /// <param name="pageSize">The page size</param>
    /// <param name="searchValue">The search value</param>
    /// <param name="sortColumn">The sort column</param>
    /// <param name="sortColumnDirection">The sort column direction</param>
    /// <exception cref="NotImplementedException"></exception>
    /// <returns>A list of category</returns>
    public List<Category> GetPaged(int skip, int pageSize, string? searchValue, string? sortColumn,
        string? sortColumnDirection)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the user with role using the specified user id
    /// </summary>
    /// <param name="userId">The user id</param>
    /// <returns>The user</returns>
    public User GetUserWithRole(int userId)
    {
        return DbSet.Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role).FirstOrDefault(u => u.Id == userId);
    }

    /// <summary>
    /// Detaches the user
    /// </summary>
    /// <param name="user">The user</param>
    public void Detach(User user)
    {
        Context.Entry(user).State = EntityState.Detached;
    }
}