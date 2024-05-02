namespace FA.LibraryManagement.API.ViewModels;

/// <summary>

/// The reset password vm class

/// </summary>

public class ResetPasswordVm
{
    /// <summary>
    ///     Gets or sets the email
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///     Gets or sets the password
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    ///     Gets or sets the token
    /// </summary>
    public string Token { get; set; }
}