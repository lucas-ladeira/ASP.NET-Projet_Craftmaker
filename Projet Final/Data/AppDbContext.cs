using Microsoft.EntityFrameworkCore;
using Projet_Final.Models;

namespace Projet_Final.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Types de meubles initiaux pour l'application. NOTE : il devrait être possible d'ajouter d'autres options si nécessaire.
			modelBuilder.Entity<FurnitureType>().HasData(
				new FurnitureType { Id = 1, Name = "Personnalisés" },
				new FurnitureType { Id = 2, Name = "Tables" },
				new FurnitureType { Id = 3, Name = "Portes" },
				new FurnitureType { Id = 4, Name = "Armoires" },
				new FurnitureType { Id = 5, Name = "Chaises" },
				new FurnitureType { Id = 6, Name = "Frises" },
				new FurnitureType { Id = 7, Name = "Sculptures" }
			);

			// Un meuble ne peut avoir qu'un seul TypeFurniture, mais un TypeFurniture peut avoir N meubles.
			modelBuilder.Entity<Furniture>()
				.HasOne(f => f.TypeFurniture)
				.WithMany(tf => tf.Furnitures)
				.HasForeignKey(f => f.TypeFurnitureId);

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<FurnitureType> FurnitureTypes { get; set; }
		public DbSet<Furniture> Furnitures { get; set; }

		// Ajout des tables pour la gestion des commandes
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }

		// Ajout de la table pour le panier
		public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
	}
}
