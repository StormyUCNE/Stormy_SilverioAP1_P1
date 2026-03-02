using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Stormy_SilverioAP1_P1.Models;

public class DetallesHuacales
{
    [Key]
    public int DetalleId { get; set; }
    public int EntradaId { get; set; }
    public int TipoId { get; set; }
    public int Cantidad { get; set; }
    public decimal Precio { get; set; }

    [ForeignKey("EntradaId")]
    public EntradasHuacales? EntradasHuacales { get; set; }

    [ForeignKey("TipoId")]
    public TiposHuacales? TiposHuacales { get; set; }
}