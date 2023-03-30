using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.AppDbContext;
using WebApplication1.Models;

namespace WebApplication1.Request.CategoriarRequests;

public class CategoriaEditar
{
    public CategoriaEditar(string Nome, string EditadorPor)
    {
        this.Nome = Nome;
        this.EditadorPor = EditadorPor;
        DataEdição=DateTime.Now;
    }
    public string Nome { get; set; }
    public DateTime DataEdição { get; set; }
    public string EditadorPor { get; set;}
   
    



}
