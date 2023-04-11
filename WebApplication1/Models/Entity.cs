namespace WebApplication1.Models;

public abstract class Entity
{

    public int Id { get; set; }
    public string Nome { get; set; }
    public string CriadoPor { get; set; }
    public DateTime DataCriação { get; set; }
    public string? EditadoPor { get; set; }
    public DateTime? Editado { get; set; }




}
