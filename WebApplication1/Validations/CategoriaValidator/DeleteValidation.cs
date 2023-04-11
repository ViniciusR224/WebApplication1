using FluentValidation;
using NuGet.Protocol;
using WebApplication1.AppDbContext;

namespace WebApplication1.Validations.CategoriaValidator
{
    public class DeleteValidation:AbstractValidator<int>
    {
        protected readonly ApplicationDbContext context;

        public DeleteValidation(ApplicationDbContext context)
        {
            this.context = context;
            RuleFor(param=>param).NotNull().NotEmpty().Must(Verificação).WithMessage("Categoria não existente").WithErrorCode("404").WithName("Id");
        }
        public bool Verificação(int id)
        {
            return context.Categorias.Any(c => c.Id == id);
        }
    }
}