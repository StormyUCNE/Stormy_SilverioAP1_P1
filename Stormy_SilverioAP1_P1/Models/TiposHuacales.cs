using System.ComponentModel.DataAnnotations;
namespace Stormy_SilverioAP1_P1.Models;

public class TiposHuacales
{
    [Key]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "Este Campo es Requerido")]
    public string Descripcion { get; set; } = string.Empty;

    [Required(ErrorMessage = "Este Campo es Requerido")]
    [Range(0, int.MaxValue, ErrorMessage = "Cantidad no puede ser negativa")]
    public int Existencia { get; set; }
}