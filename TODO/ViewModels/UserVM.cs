using System.ComponentModel.DataAnnotations;

public class UserVM
{
    [Required]
    public string Login { get; set; }

    [Required]
    public string Password { get; set; }
}
