using System.ComponentModel.DataAnnotations;

namespace Projet_Final.Models
{
	public class ShoppingCartItem
	{
		[Key]
		public int Id { get; set; }
		public Furniture Furniture { get; set; }
		public int Amount { get; set; }

		// ID unique du panier pour chaque utilisateur, utilisé pour relier les articles au bon panier
		public string ShoppingCartId { get; set; }
	}
}
