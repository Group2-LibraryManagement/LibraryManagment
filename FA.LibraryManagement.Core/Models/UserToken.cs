using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace FA.LibraryManagement.Core.Models;

/// <summary>

/// The user token class

/// </summary>

/// <seealso cref="IdentityUserToken{int}"/>

[Table("UserTokens")]
public class UserToken : IdentityUserToken<int>
{
    /// <summary>
    /// Gets or sets the value of the user
    /// </summary>
    public virtual User? User { get; set; }
}