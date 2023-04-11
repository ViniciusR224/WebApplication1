using WebApplication1.Models;

namespace WebApplication1.Response
{
    public class CategoriaResponse
    {
        
        //Orra finalmente consegui retornar esse porcaria, estava com uma dificuldade para entender como essa merda iria retornar um lista 
        //dela mesma, acabei colocando até mesmo uma propriedade list<categoriaresponse>, mas fazendo o loop acabava retorna uma list vazia também
        //foi ai que lembrei que o objeto em si não precisava ser uma list,eu tinha até mesmo usado o ctor para receber o request
        //mas acabava tendo o problema na hora de fazer o loop, porque como ele vai construir uma categoria se no ctor precisa do request
        //, era só usar a classe como objeto e fazer os métodos dentro dela que recebessem , dai não teria problema com os parametros, mas que burrice e falta de atenção de cair o cu da bunda
        //mas consegui fazer essa bagaça retornar, mais uma coisa a se aprender, literalmente se lembrar da ORIENTAÇÃO A OBJETOS kek, é foda. 
        public List<CategoriaResponse> GetList(List<Categoria> categorias)//Tome cuidado com os nomes, eu tinha colocado List só e ficava dando merda
        {
            var list = new List<CategoriaResponse>();
            foreach (var c in categorias)
            {
                var categoria = new CategoriaResponse()
                {
                    Nome = c.Nome,
                    CriadoPoR = c.CriadoPor
                };
                list.Add(categoria);
            };
            return list;
            
        }
        public string Nome { get; set; }    
        public string CriadoPoR { get;set; }
        

    }
}
