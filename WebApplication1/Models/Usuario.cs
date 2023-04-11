using Microsoft.AspNetCore.Mvc;
using WebApplication1.AppDbContext;
using WebApplication1.Request;
using WebApplication1.Request.CategoriarRequests;
using WebApplication1.Response;

namespace WebApplication1.Models;

public class Usuario:Entity
{
    public Categoria Tipo { get; set; }
    public int TipoId { get; set; }
    

  
    
    
}
