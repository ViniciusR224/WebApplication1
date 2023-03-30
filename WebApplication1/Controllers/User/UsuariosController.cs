using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebApplication1.AppDbContext;
using WebApplication1.Models;
using WebApplication1.Request;
using WebApplication1.Repository;
using NuGet.DependencyResolver;

namespace WebApplication1.Controllers.User
{
    [ApiController]
    [Route("/[controller]")]
    public class UsuariosController : Controller
    {
        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;   //Lembre-se que você deve inicializar o dbcontext
        }
        protected ApplicationDbContext _context; //Até porque isso aqui é só uma propriedade de um certo tipo
                                                 //Logo se não inicializar com um valor é null


        [HttpGet("/Usuarios")]      
        public IResult ObterInformações()
        {
            var Usuarios = _context.Usuarios;
            return Results.Ok(Usuarios);
        }
        [HttpGet("/Usuario/{id}")]
        public IResult ObterInformações([FromRoute] int id)
        {
            var produto = _context.Usuarios.First(User => User.Id == id); //Tome cuidado ao usar o where, ele vai verificar todos, então coloque o First() para funcionar       
            return Results.Ok(produto);
        }


        [HttpPost("/Usuarios")]
        public IResult InserirUsuario(UsuarioRequest request)
        {
            var instancia = new UserRepository(_context);
            var usuario = new Usuario()
            {
                Name = request.Name,
            };
            instancia.AdicionarUsuario(usuario);
            _context.SaveChanges();
            return Results.Created($"/Usuarios/{usuario.Id}", usuario.Name);
        }
        [HttpPut("/Usuarios/{id}")]
        public IResult Atualizar([FromRoute] int id, UsuarioRequest request)
        {
            var instancia = new UserRepository(_context);
            var usuario = _context.Usuarios.Where(User => User.Id == id).First();
            instancia.AtualizarUsuario(usuario, request);
            //Parece que eu tenho que passar o context para que eu possa ter acesso
            //aos dados quando utilizo um método intermediário, se não vou ter nullreference
            return Results.Ok(_context.Usuarios.Where(c => c.Id == id));
        }
        [HttpDelete("/Delete/{id}")]
        public IResult DeletarUser([FromRoute] int id)
        {
            var instancia = new UserRepository(_context);
            var usuario = _context.Usuarios.Where(user => user.Id == id).First();
            instancia.DeletarUsuario(usuario);
            return Results.Ok($"Usuario Deletado:{usuario}");
        }
    }

}
