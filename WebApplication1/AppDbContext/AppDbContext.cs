using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.AppDbContext  //Pelo que parece se você colocar o namespace com o mesmo nome da class o scaffolding não consegue.
{
    public class ApplicationDbContext :DbContext
    {
        //Aqui faremos com o banco de dados entenda que o contexto de dados a ser recebido será esse
        //O construtor da classe AppDbContext recebe um objeto do tipo DbContextOptions<AppDbContext>
        //e passa-o para o construtor da classe base DbContext, que inicializa a instância do contexto
        //com as opções fornecidas. 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().Property(p=>p.Id).IsRequired(true);
            base.OnModelCreating(modelBuilder);
        }
    }
}
