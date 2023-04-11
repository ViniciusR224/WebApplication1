using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using WebApplication1.AppDbContext;
using WebApplication1.Models;
using WebApplication1.Request.CategoriarRequests;
using WebApplication1.Response;
using WebApplication1.Validations.CategoriaValidator;

namespace WebApplication1.Controllers.CategoriaController;

[ApiController]
[Route("/[controller]")]
public class CategoriaController:Controller
{
    public CategoriaController(ApplicationDbContext context)
    {
        this.context= context;
        var response=new CategoriaResponse();   
        Response=response;
    }
    protected readonly ApplicationDbContext context;
    protected readonly CategoriaResponse Response;
    
    [HttpGet("/Categorias")]
    public IResult Categorias()
    {
        
        var request = context.Categorias.ToList();       
        var response = Response.GetList(request);
        return Results.Ok(response);
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
    public IResult CategoriaAtt([FromRoute]int id,CategoriaEditar categoriaEditar)
    {
        var verification = new IdValid(context);
        var result=verification.Validate(id);
        if(!result.IsValid)
        {
            return Results.BadRequest(result.Errors);
        }
        var cat=Categoria.EditFromRequest(id,categoriaEditar, context);
        context.SaveChanges();
        return Results.Ok();
    }
    [HttpDelete("/Categoria/{id}")]
    public IResult Deletar([FromRoute]int id) 
    {
        var verificação = new DeleteValidation(context);
        var result=verificação.Validate(id);
        if(!result.IsValid)
        {
            return Results.BadRequest(result.Errors);
        }

        // Categoria.Deletar(id, context);
        return Results.Ok();
    }
}
