using FluentValidation;
using WebApplication1.AppDbContext;
using WebApplication1.Models;
using WebApplication1.Request.UsuarioRequests;

namespace WebApplication1.Validations.UsuarioValidator
{
    public class UsuarioEditRequest : AbstractValidator<UsuarioEditar>
    {

        public UsuarioEditRequest(ApplicationDbContext Context)
        {
            RuleFor(P => P.Nome).NotEmpty().WithErrorCode("200 Bad Request - Nome deve ser informado").NotNull();
            RuleFor(p => p.EditadoPor).NotNull().NotEmpty();
        }
    }
}
