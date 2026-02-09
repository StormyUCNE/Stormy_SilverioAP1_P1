using System.ComponentModel.DataAnnotations;
namespace Stormy_SilverioAP1_P1.Models;
public class EntradasHuacales
{
    [Key]
    public int IdEntrada { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string Descripcion { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obligatorio")]
    [Range(1, Double.MaxValue, ErrorMessage = "Campo no debe contener valores negativos.")]
    public double Cost { get; set; }
}