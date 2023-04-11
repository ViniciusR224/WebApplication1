using FluentValidation;
using Microsoft.CodeAnalysis;
using Org.BouncyCastle.Crypto.Modes.Gcm;
using WebApplication1.AppDbContext;
using WebApplication1.Models;
using WebApplication1.Request.CategoriarRequests;
using WebApplication1.Request.UsuarioRequests;
using WebApplication1.Response;

namespace WebApplication1.Validations.UsuarioValidator
{

    public class UsuarioValidator : AbstractValidator<UsuarioRequest>
    {
        public UsuarioValidator(ApplicationDbContext context)
        {
            Context = context;

            RuleFor(p => p.Nome).NotEmpty().WithMessage("Nome Inválido")
                .NotNull().WithMessage("Nome não pode ser nulo")
                .MinimumLength(3).WithMessage("O nome deve possuir no mínimo 3 caracteres");
            RuleFor(p => p.CriadoPor).NotEmpty()
                .NotNull().WithMessage("Criado-Por Inválido");
            RuleFor(p => p.TipoId).NotNull().NotEmpty()
                .Must(Verificação).WithMessage("Categoria Inválida - Requer uma existente");
            
        }
        public bool Verificação(int id)
        {
            return Context.Categorias.Any(c => c.Id == id);
        }
        public readonly ApplicationDbContext Context;
    }


}
