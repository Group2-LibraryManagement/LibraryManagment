using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FA.LibraryManagement.Core.Models;

/// <summary>

/// The user login class

/// </summary>

/// <seealso cref="IdentityUserLogin{int}"/>

[Table("UserLogins")]
public class UserLogin : IdentityUserLogin<int>
{
    /// <summary>
    /// Gets or sets the value of the user id
    /// </summary>
    public int UserId { get; set; }
    /// <summary>
    /// Gets or sets the value of the user
    /// </summary>
    public virtual User User { get; set; } = null!;
}