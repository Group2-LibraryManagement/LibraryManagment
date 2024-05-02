using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FA.LibraryManagement.Core.Models;

/// <summary>

/// The user class

/// </summary>

/// <seealso cref="IdentityUser{int}"/>

[Table("Users")]
public class User : IdentityUser<int>
{
    /// <summary>
    /// Gets or sets the value of the image data
    /// </summary>
    public byte[]? UserImage { get; set; }
    /// <summary>
    /// Gets or sets the value of the claims
    /// </summary>
    public virtual ICollection<UserClaim> Claims { get; set; }
    /// <summary>
    /// Gets or sets the value of the logins
    /// </summary>
    public virtual ICollection<UserLogin> Logins { get; set; }
    /// <summary>
    /// Gets or sets the value of the tokens
    /// </summary>
    public virtual ICollection<UserToken> Tokens { get; set; }
    /// <summary>
    /// Gets or sets the value of the user roles
    /// </summary>
    public virtual ICollection<UserRole> UserRoles { get; set; }
}