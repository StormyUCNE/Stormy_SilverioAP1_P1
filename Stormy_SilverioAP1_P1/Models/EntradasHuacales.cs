using System.ComponentModel.DataAnnotations;
namespace Stormy_SilverioAP1_P1.Models;
public class EntradasHuacales
{
    [Key]
    public int EntradaId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string Nombre { get; set; } = string.Empty;
    public ICollection<DetallesHuacales> ListaHuacales { get; set; } = new List<DetallesHuacales>();
}