using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace FA.LibraryManagement.API.ViewModels;

/// <summary>
///     The category vm class
/// </summary>
public class CategoryVm
{
    /// <summary>
    ///     Gets or sets the value of the id
    /// </summary>
    [ValidateNever]
    public int Id { get; set; }

    /// <summary>
    ///     Gets or sets the value of the category name
    /// </summary>
    [Required(ErrorMessage = "Category name is required")]
    [MaxLength(50, ErrorMessage = "Category name can not be more than 50 characters")]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the value of the url slug
    /// </summary>
    public string UrlSlug { get; set; }

    /// <summary>
    ///     Gets or sets the value of the description
    /// </summary>
    public string? Description { get; set; }
}