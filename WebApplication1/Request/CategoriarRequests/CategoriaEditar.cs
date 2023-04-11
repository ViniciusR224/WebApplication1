using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.AppDbContext;
using WebApplication1.Models;

namespace WebApplication1.Request.CategoriarRequests;

public record CategoriaEditar( string Nome, string EditadorPor);

