using WebApplication1.AppDbContext;
using WebApplication1.Models;
using WebApplication1.Request;

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
        public void AdicionarUsuario(Usuario user)
        {
            _context.Add(user);
        }
        public void AtualizarUsuario(Usuario usuario,UsuarioRequest request) 
        {
            usuario.Name= request.Name;
            _context.SaveChanges();
        }
        public void DeletarUsuario(Usuario usuario)
        {
            _context.Remove(usuario);
            _context.SaveChanges();
        }


    }
}
