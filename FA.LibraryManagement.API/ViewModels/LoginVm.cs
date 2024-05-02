using System.ComponentModel.DataAnnotations;

namespace FA.LibraryManagement.API.ViewModels;

/// <summary>
///     The login vm class
/// </summary>
public class LoginVm
{
    /// <summary>
    ///     Gets or sets the value of the email
    /// </summary>
    [Required(ErrorMessage = "Username is required!")]
    public string Email { get; set; }

    /// <summary>
    ///     Gets or sets the value of the password
    /// </summary>
    [Required(ErrorMessage = "Password is required!")]
    public string Password { get; set; }
}