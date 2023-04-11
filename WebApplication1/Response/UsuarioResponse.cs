using WebApplication1.Models;

namespace WebApplication1.Response
{
    public class UsuarioResponse
    {

       
        
        public List<UsuarioResponse> GetList(List<Usuario> usuarios)
        {
            var list = new List<UsuarioResponse>();
            foreach (var item in usuarios)
            {
                var user=new UsuarioResponse
                {
                    Nome = item.Nome,
                    CriadoPor = item.CriadoPor,
                };
                list.Add(user);
            }
            return list;
        }
        public string Nome { get; set; }
        public string CriadoPor { get;set; }
    }
}
