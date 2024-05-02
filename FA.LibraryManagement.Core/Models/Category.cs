using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.LibraryManagement.Core.Models;

/// <summary>
///     The category class
/// </summary>
[Table("Categories")]
public class Category
{
    /// <summary>
    ///     Gets or sets the value of the id
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    ///     Gets or sets the value of the name
    /// </summary>
    [Required(ErrorMessage = "Category name is required.")]
    [StringLength(255)]
    public string Name { get; set; }

    /// <summary>
    ///     Gets or sets the value of the url slug
    /// </summary>
    [StringLength(255)]
    public string UrlSlug { get; set; }

    /// <summary>
    ///     Gets or sets the value of the description
    /// </summary>
    [StringLength(1024)]
    public string? Description { get; set; }
}