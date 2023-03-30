using Microsoft.AspNetCore.Mvc;
using WebApplication1.AppDbContext;
using WebApplication1.Models;
using WebApplication1.Request.CategoriarRequests;

namespace WebApplication1.Controllers.CategoriaController;

[ApiController]
[Route("/[controller]")]
public class CategoriaController:Controller
{
    public CategoriaController(ApplicationDbContext context)
    {
        this.context= context;
    }
    protected readonly ApplicationDbContext context;
    [HttpGet("/Categorias")]
    public IResult Categorias()
    {
        var Categorias = context.Usuarios;
        return Results.Ok(Categorias);
    }
    [HttpPost("/Categorias")]
    public IResult Categoria1([FromBody]CategoriaRequest categoriaRequest)
    {
        var categoria = Categoria.FromRequest(categoriaRequest);
        context.Add(categoria);
        context.SaveChanges();
        return Results.Ok();
    }
    [HttpPut("/Categoria/{id}")]
    public IResult CategoriaAtt([FromRoute]int id, [FromBody]CategoriaEditar categoriaEditar)
    {
        
        var cat=Categoria.EditFromRequest(id, categoriaEditar, context);
        context.SaveChanges();
        return Results.Ok();
    }
    [HttpDelete("/Categoria/{id}")]
    public IResult Deletar([FromRoute]int id) 
    {
        
        return Categoria.Deletar(id, context);//Tipo isso o que eu estava falando de fazer direto
    }
}
