using System.ComponentModel.DataAnnotations;

namespace FA.LibraryManagement.API.ViewModels;

/// <summary>
///     The register vm class
/// </summary>
public class RegisterVm
{
    /// <summary>
    ///     Gets or sets the value of the user name
    /// </summary>
    [Required(ErrorMessage = "UserName is required!")]
    public string UserName { get; set; }

    /// <summary>
    ///     Gets or sets the value of the email
    /// </summary>
    [Required(ErrorMessage = "Email is required!")]
    public string Email { get; set; }

    /// <summary>
    ///     Gets or sets the value of the password
    /// </summary>
    [Required(ErrorMessage = "Password is required!")]
    public string Password { get; set; }
}