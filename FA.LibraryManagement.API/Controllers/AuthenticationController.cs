using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FA.LibraryManagement.API.ViewModels;
using FA.LibraryManagement.Core.Context;
using FA.LibraryManagement.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FA.LibraryManagement.API.Controllers;

/// <summary>
///     The authentication controller class
/// </summary>
/// <seealso cref="ControllerBase" />
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController(
    UserManager<User> _userManager,
    SignInManager<User> _signInManager,
    RoleManager<Role> _roleManager,
    LibraryManagementContext _context,
    IConfiguration _configuration) : ControllerBase
{
    /// <summary>
    ///     Registers the register
    /// </summary>
    /// <param name="register">The register</param>
    /// <returns>A task containing the action result</returns>
    [HttpPost("register-user")]
    public async Task<IActionResult> Register([FromBody] RegisterVm register)
    {
        var userExists = await _userManager.FindByEmailAsync(register.Email);

        if (userExists != null) return BadRequest($"User {userExists.Email} already exists!");

        var newUser = new User
        {
            UserName = register.UserName,
            Email = register.Email,
            SecurityStamp = new Guid().ToString()
        };

        var result = await _userManager.CreateAsync(newUser, register.Password);

        if (result.Succeeded) return Created(nameof(Register), $"{register.Email} created!");

        return BadRequest("User could not create!");
    }

    /// <summary>
    ///     Logins the login
    /// </summary>
    /// <param name="login">The login</param>
    /// <returns>A task containing the action result</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginVm login)
    {
        if (!ModelState.IsValid) return BadRequest("Errors");

        var user = await _userManager.FindByEmailAsync(login.Email);

        if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
        {
            var tokenValue = await GenerateJwtToken(user);

            _signInManager.SignInAsync(user, false);

            return Ok(tokenValue);
        }

        return Unauthorized();
    }

    /// <summary>
    /// Forgots the password using the specified forgot password
    /// </summary>
    /// <param name="forgotPassword">The forgot password</param>
    /// <returns>A task containing the action result</returns>
    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordVm forgotPassword)
    {
        var user = await _userManager.FindByEmailAsync(forgotPassword.Email);
        if (user == null) return BadRequest("User not found!");

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        //var passwordResetLink = Url.Action("ResetPassword", "Authentication", new { email = forgotPassword.Email, token = token }, Request.Scheme);
        return Ok(token);
    }

    /// <summary>
    /// Resets the password using the specified reset password
    /// </summary>
    /// <param name="resetPassword">The reset password</param>
    /// <returns>A task containing the action result</returns>
    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordVm resetPassword)
    {
        var user = await _userManager.FindByEmailAsync(resetPassword.Email);
        if (user == null) return BadRequest("User not found!");

        var resetPassResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
        if (resetPassResult.Succeeded) return Ok("Password reset successful!");

        return BadRequest("Password reset failed!");
    }

    /// <summary>
    /// Refreshes the token using the specified refresh token
    /// </summary>
    /// <param name="refreshToken">The refresh token</param>
    /// <returns>A task containing the action result</returns>
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenVm refreshToken)
    {
        var user = await _userManager.FindByEmailAsync(refreshToken.Email);
        if (user == null) return BadRequest("User not found!");

        var oldRefreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.Token == refreshToken.Token);
        if (oldRefreshToken.IsRevoke) return BadRequest("Token has been revoked!");

        if (oldRefreshToken.DateExpire < DateTime.UtcNow) return BadRequest("Token has expired!");

        var jwtToken = await GenerateJwtToken(user);
        return Ok(jwtToken);
    }

    /// <summary>
    ///     Generates the jwt token using the specified user
    /// </summary>
    /// <param name="user">The user</param>
    /// <returns>The response</returns>
    private async Task<AuthResultVm> GenerateJwtToken(User user)
    {
        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.Sub, user.Email),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));
        var token = new JwtSecurityToken(
            _configuration["JWT:Issuer"],
            _configuration["JWT:Audience"],
            expires: DateTime.UtcNow.AddMinutes(5), // 5 - 10mins
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );
        var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
        var refreshToken = new RefreshToken
        {
            JwtId = token.Id,
            IsRevoke = false,
            UserId = user.Id,
            DateAdded = DateTime.UtcNow,
            DateExpire = DateTime.UtcNow.AddMonths(6),
            Token = Guid.NewGuid() + "-" + Guid.NewGuid()
        };
        await _context.RefreshTokens.AddAsync(refreshToken);
        await _context.SaveChangesAsync();
        var response = new AuthResultVm
        {
            Token = jwtToken,
            RefreshToken = refreshToken.Token,
            ExpiresAt = token.ValidTo
        };
        return response;
    }
}