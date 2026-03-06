namespace FoodCampus.Application.DTOs;

public class PlatilloDto
{
    public int IdPlatillo { get; set; }
    public int IdRestaurante { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public string? Descripcion { get; set; }
}
