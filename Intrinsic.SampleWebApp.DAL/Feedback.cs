using System.ComponentModel.DataAnnotations;

namespace Intrinsic.SampleWebApp.DAL;

public class Feedback
{
    [Key]
    public Guid Id { get; set; }

    [MaxLength(100)]
    public string Author { get; set; }

    public string Content { get; set; }

    public DateTimeOffset Created { get; set; }
}