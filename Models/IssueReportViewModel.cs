using System.ComponentModel.DataAnnotations;

namespace DevWebsiteMVC.Models;

public class IssueReportViewModel
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(256)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(150)]
    public string Subject { get; set; } = string.Empty;

    [Required]
    [StringLength(4000, MinimumLength = 10)]
    public string Description { get; set; } = string.Empty;
}
