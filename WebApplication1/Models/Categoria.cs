using Microsoft.AspNetCore.Mvc;
using WebApplication1.AppDbContext;
using WebApplication1.Request.CategoriarRequests;

namespace WebApplication1.Models;

public class Categoria
{
    public static IResult Deletar([FromRoute]int id,ApplicationDbContext context)
    {
        var cat = context.Categorias.First(cat=>cat.Id==id);
        if(cat == null)
        {
            return Results.NotFound();
        }
        else
        {
            context.Categorias.Remove(cat);
            context.SaveChanges();
            return Results.Ok();
        }
        
    }
    public static Categoria EditFromRequest(int id,CategoriaEditar request, ApplicationDbContext context)
    {
        var cat = context.Categorias.First(cat=>cat.Id==id);
        cat.Nome = request.Nome;
        cat.EditadoPor = request.EditadorPor;
        cat.Editado = request.DataEdição;
        return cat;
    }//Caso você queira retornar coloque um retorno de categoria, mas se não é só deixar como void e dar o save aqui
    
    public static Categoria FromRequest(CategoriaRequest request)
    {
        return new Categoria    //Nesse caso se eu colocasse direto no construtor daria merda, Entity Framework Core não sabe como criar uma instância da classe Categoria a partir de uma instância de CategoriaRequest
        {
            Nome = request.Nome,
            CriadoPor = request.CriadoPor,
            DataCriação = request.DateCriação
        };
    }
    public int Id { get; set; }
    public string Nome { get; set; }
    public string CriadoPor { get; set; }
    public DateTime DataCriação { get; set; }
    public string? EditadoPor { get; set; }
    public DateTime? Editado { get; set; }
}







