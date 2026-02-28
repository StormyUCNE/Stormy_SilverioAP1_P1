using System.ComponentModel.DataAnnotations;
namespace Stormy_SilverioAP1_P1.Models;

public class TiposHuacales
{
    [Key]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "Este Campo es Requerido")]
    public string Descripcion { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo es Requerido")]
    [Range(1, int.MaxValue, ErrorMessage = "Cantidad debe de ser mayor a cero")]
    public int Existencia { get; set; }
}