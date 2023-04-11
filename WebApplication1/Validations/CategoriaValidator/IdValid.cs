using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.AppDbContext;

namespace WebApplication1.Validations.CategoriaValidator;


public class IdValid:AbstractValidator<int>
{
    public readonly ApplicationDbContext Context;
    public IdValid(ApplicationDbContext dbContext)
    {
        Context = dbContext;
        RuleFor(param=>param).NotNull().NotEmpty().Must(Verificação).WithMessage("Id inválido");
    }
    public bool Verificação(int id)
    {
        return Context.Categorias.Any(c => c.Id == id);
    }
}
