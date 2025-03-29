using System.ComponentModel.DataAnnotations;

namespace Projet_Final.Models
{
	public class FurnitureType
	{
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Le nom est requis")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Le nom doit contenir au moins 3 caractères")]
		public string? Name { get; set; }

		// Relationships
		public List<Furniture>? Furnitures { get; set; }
	}
}
