using System.ComponentModel.DataAnnotations.Schema;

namespace FA.LibraryManagement.Core.Models;

/// <summary>
///     The refresh token class
/// </summary>
[Table("RefreshTokens")]
public class RefreshToken
{
    /// <summary>
    ///     Gets or sets the value of the id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     Gets or sets the value of the user id
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    ///     Gets or sets the value of the token
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    ///     Gets or sets the value of the jwt id
    /// </summary>
    public string JwtId { get; set; }

    /// <summary>
    ///     Gets or sets the value of the is revoke
    /// </summary>
    public bool IsRevoke { get; set; }

    /// <summary>
    ///     Gets or sets the value of the date added
    /// </summary>
    public DateTime DateAdded { get; set; }

    /// <summary>
    ///     Gets or sets the value of the date expire
    /// </summary>
    public DateTime DateExpire { get; set; }

    /// <summary>
    ///     Gets or sets the value of the user
    /// </summary>
    public virtual User User { get; set; }
}