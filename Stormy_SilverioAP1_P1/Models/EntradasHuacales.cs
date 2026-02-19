using System.ComponentModel.DataAnnotations;
namespace Stormy_SilverioAP1_P1.Models;
public class EntradasHuacales
{
    [Key]
    public int IdEntrada { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string NombreCliente { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "Campo no debe contener valores menor a 1")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    [Range(1, Double.MaxValue, ErrorMessage = "Campo no debe contener valores menor a 1.")]
    public decimal Precio { get; set; }
}