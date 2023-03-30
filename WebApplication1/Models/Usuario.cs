namespace WebApplication1.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Categoria Tipo { get; set; }
    public int TipoId { get; set; }
    public string CriadoPor { get; set; }
    public DateTime DataCriação { get; set; }
    public string EditadoPor { get; set; }
    public DateTime Editado { get; set; }
}
