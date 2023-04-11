using FluentValidation;
using WebApplication1.AppDbContext;
using WebApplication1.Request.CategoriarRequests;

namespace WebApplication1.Validations.CategoriaValidator
{
    public class CategoriaEditRequest:AbstractValidator<CategoriaEditar>
    {
        public readonly ApplicationDbContext DbContext;
        public CategoriaEditRequest(ApplicationDbContext context)
        {

            DbContext = context;
            
            RuleFor(cat=>cat.Nome).NotEmpty().WithMessage("Nome não pode ser vazio").NotNull().Must(VerificarDuplo).WithMessage("Nome já existente - Ação não permitida");
            RuleFor(cat => cat.EditadorPor).NotEmpty().WithMessage("Não pode ser vazio").NotNull();

        }
        public bool VerificarDuplo(string nome)
        {
            var verificacao = DbContext.Categorias.FirstOrDefault(c => c.Nome == nome);
            return verificacao is null;
        }
        
    }
}
