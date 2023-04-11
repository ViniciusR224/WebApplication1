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
using WebApplication1.Repository;
using NuGet.DependencyResolver;
using WebApplication1.Response;
using WebApplication1.Request.UsuarioRequests;
using WebApplication1.Validations.UsuarioValidator;
using MySqlX.XDevAPI.Common;

namespace WebApplication1.Controllers.User
{
    [ApiController]
    [Route("/[controller]")]
    public class UsuariosController : Controller
    {
        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;   //Lembre-se que você deve inicializar o dbcontext
            userRepository = new UserRepository(context);
            Response = new UsuarioResponse();
        }
        protected readonly ApplicationDbContext _context; //Até porque isso aqui é só uma propriedade de um certo tipo
        protected readonly UserRepository userRepository;  //Logo se não inicializar com um valor é null
        protected readonly UsuarioResponse Response;

        [HttpGet("/Usuarios")]
        public IResult ObterInformações()
        {
            var Usuarios = _context.Usuarios.ToList();
            var lista = Response.GetList(Usuarios);
            return Results.Ok(lista);
        }
        [HttpGet("/Usuario/{id}")]
        public IResult ObterInformações2([FromRoute] int id)
        {
            var usuario = _context.Usuarios.First(User => User.Id == id); //Tome cuidado ao usar o where, ele vai verificar todos, então coloque o First() para funcionar       
            var response = new UsuarioResponse() { Nome = usuario.Nome, CriadoPor = usuario.CriadoPor };
            return Results.Ok(response);
        }


        [HttpPost("/Usuarios")]
        public IResult InserirUsuario(UsuarioRequest request)
        {           
            var usuario=userRepository.AdicionarUsuario(request);           
            _context.SaveChanges();
            return Results.Created($"/Usuarios/{usuario.Id}", usuario.Nome);
        }
        [HttpPut("/Usuario/{id}")]
        public IResult Atualizar([FromRoute] int id, [FromBody]UsuarioEditar request)
        {
            userRepository.AtualizarUsuario(id,request);
            return Results.Ok();
        }
        [HttpDelete("/Delete/{id}")]
        public IResult DeletarUser([FromRoute]int id)
        {
            
            return userRepository.DeletarUsuario(id);
        }
    }

}
