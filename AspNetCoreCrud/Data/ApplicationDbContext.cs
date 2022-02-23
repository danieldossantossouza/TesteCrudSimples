using AspNetCoreCrud.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreCrud.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}
		public DbSet<CadastroViagem> CadastroViagens { get; set; }
		public DbSet<Motorista> Motoristas { get; set; }
		public DbSet<Endereco> Enderecos { get; set; }
		public DbSet<Caminhao> Caminhoes { get; set; }



	}
}
