

using System.Data.Entity.ModelConfiguration.Conventions;
using CadastroContatosEntityFramework.Models;
using System.Data.Entity;

namespace CadastroContatosEntityFramework.Context
{
    public class ContatoMVCContext : DbContext
    {
        //Chama o construtor da Classe base e passa uma conection String.
        public ContatoMVCContext() 
            : base("ContatoMVC")
        {

        }

        public DbSet<Contato> Contato { get; set; }

        //Método que tem como convenção não pluralizar o nome das tabelas no plural.
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}