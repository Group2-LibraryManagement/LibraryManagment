namespace FA.LibraryManagement.API.ViewModels;

/// <summary>
///     The auth result vm class
/// </summary>
public class AuthResultVm
{
    /// <summary>
    ///     Gets or sets the value of the token
    /// </summary>
    public string Token { get; set; }

    /// <summary>
    ///     Gets or sets the value of the refresh token
    /// </summary>
    public string RefreshToken { get; set; }

    /// <summary>
    ///     Gets or sets the value of the expires at
    /// </summary>
    public DateTime ExpiresAt { get; set; }
}