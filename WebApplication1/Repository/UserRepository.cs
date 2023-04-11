using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using WebApplication1.AppDbContext;
using WebApplication1.Models;
using WebApplication1.Request.UsuarioRequests;
using WebApplication1.Response;

namespace WebApplication1.Repository
{
    public class UserRepository 
    {
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public static List<Usuario> Usuarios= new List<Usuario>();
        public readonly ApplicationDbContext _context;
        public Usuario AdicionarUsuario([FromBody]UsuarioRequest request)
        {
            var usuario = new Usuario()
            {
                Nome = request.Nome,
                CriadoPor = request.CriadoPor,
                TipoId = request.TipoId, 
                DataCriação=DateTime.Now,
            };
            _context.Add(usuario);
            return usuario;
        }
        public void AtualizarUsuario(int id,[FromBody]UsuarioEditar editar) 
        {
            var usuario = _context.Usuarios.First(p => p.Id == id);          
            usuario.Nome= editar.Nome;
            usuario.EditadoPor= editar.EditadoPor;
            usuario.Editado = DateTime.Now;
            _context.SaveChanges();
        }
        public IResult DeletarUsuario(int id)
        {
            var user=_context.Usuarios.FirstOrDefault(user=> user.Id == id);
            if (user == null)
            {
                return Results.BadRequest("Usuário Inválido");
            }
            _context.Usuarios.Remove(user);
            _context.SaveChanges();
            return Results.Ok(user);
            
        }

        
    }
}
