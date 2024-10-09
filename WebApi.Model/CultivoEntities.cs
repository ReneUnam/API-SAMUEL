namespace WebApi.Model;

public class CultivoEntities
{
    public int Id { get; set; } 
    public string Nombre { get; set; }
    public string EstacionCrecimiento { get; set; } //Primavera, Verano, Otoño, Invierno.
    public int TiempoCrecimiento { get; set; } //Días hasta la cosecha.
    public string EstadoCrecimiento { get; set; } //Sembrado, Germinando, Listo para cosechar.
    public int FrecuenciaRiego { get; set; } //Días entre riegos.
    public string FertilizanteUsado { get; set; } //Si aplica
    public decimal ValorVenta { get; set; } //Precio estimado por unidad
    public DateTime FechaSiembra { get; set; }
    public DateTime FechaCompra { get; set; }
}