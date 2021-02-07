using CursosMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CursosMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Curso> Cursos { get; set; }

    }
}
