using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stormy_SilverioAP1_P1.Models;

public class DetallesHuacales
{
    [Key]
    public int DetalleId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public int EntradaId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "Cantidad debe de ser mayor a cero")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    [Range(1, Double.MaxValue, ErrorMessage = "Cantidad debe de ser mayor a cero")]
    public decimal Precio { get; set; }

    [ForeignKey("EntradaId")]
    public EntradasHuacales? EntradasHuacales { get; set; }

    [ForeignKey("TipoId")]
    public TiposHuacales? TiposHuacales { get; set; }
}