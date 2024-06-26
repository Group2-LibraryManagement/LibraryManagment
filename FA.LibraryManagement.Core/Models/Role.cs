using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FA.LibraryManagement.Core.Models;

/// <summary>

/// The role class

/// </summary>

/// <seealso cref="IdentityRole{int}"/>

[Table("Roles")]
public class Role : IdentityRole<int>
{
    /// <summary>
    /// Gets or sets the value of the role id
    /// </summary>
    [Key] public int RoleId { get; set; }

    /// <summary>
    /// Gets or sets the value of the description
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Gets or sets the value of the users
    /// </summary>
    public virtual ICollection<User>? Users { get; set; }
    /// <summary>
    /// Gets or sets the value of the user roles
    /// </summary>
    public virtual ICollection<UserRole> UserRoles { get; set; }
    /// <summary>
    /// Gets or sets the value of the role claims
    /// </summary>
    public virtual ICollection<RoleClaim> RoleClaims { get; set; }
}