using System.ComponentModel.DataAnnotations;

public class TodoVM
{
    [Required]
    public string Libelle { get; set; }

    public string Description { get; set; }

    [Required]
    public string State { get; set; } // ToDo - Doing - Done

    [Required]
    public DateTime DateLimite { get; set; }
}
