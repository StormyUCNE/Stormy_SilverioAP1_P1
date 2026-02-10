using System.ComponentModel.DataAnnotations;
namespace Stormy_SilverioAP1_P1.Models;
public class EntradasHuacales
{
    [Key]
    public int IdEntrada { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public DateOnly Fecha { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string NombreCliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "Campo no debe contener valores negativos.")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    [Range(1, Double.MaxValue, ErrorMessage = "Campo no debe contener valores negativos.")]
    public decimal Precio { get; set; }
}