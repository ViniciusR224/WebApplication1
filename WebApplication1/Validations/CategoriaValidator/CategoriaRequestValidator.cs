using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WebApplication1.AppDbContext;
using WebApplication1.Request.CategoriarRequests;

namespace WebApplication1.Validations.CategoriaValidator
{
    public class CategoriaRequestValidator:AbstractValidator<CategoriaRequest>
    {
        
        public CategoriaRequestValidator(ApplicationDbContext dbContext)
        {
            Context = dbContext;
            RuleFor(cat => cat.Nome).NotEmpty().NotNull().Must(VerificarDuplo).WithMessage("Nome já existente - Ação não permitida"); 
            RuleFor(cat => cat.CriadoPor).NotNull().NotEmpty();

        }
        public readonly ApplicationDbContext Context;
        public bool VerificarDuplo(string nome)
        {
            var verificacao = Context.Categorias.FirstOrDefault(c => c.Nome == nome);
            return verificacao is null;
        }
        
    }
}
