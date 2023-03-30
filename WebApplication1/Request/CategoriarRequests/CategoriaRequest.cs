using Microsoft.AspNetCore.Mvc;
using WebApplication1.AppDbContext;

namespace WebApplication1.Request.CategoriarRequests;

public class CategoriaRequest
{
    public CategoriaRequest(string Nome, string CriadoPor)
    {
        this.Nome = Nome;
        this.CriadoPor = CriadoPor;
        DateCriação = DateTime.Now;

    }
    public string Nome { get; set; }
    public string CriadoPor { get; set; }
    public DateTime DateCriação { get; set; }


}
