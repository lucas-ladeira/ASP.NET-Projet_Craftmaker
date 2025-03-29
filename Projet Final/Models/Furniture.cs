using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_Final.Models
{
	public class Furniture
	{
		// Properties
		[Key]
		public int Id { get; set; }
		[Required(ErrorMessage = "Le nom est requis")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Le nom doit contenir au moins 3 caractères")]
		public string? Name { get; set; }
		[Required(ErrorMessage = "La description est requise")]
		[StringLength(255, MinimumLength = 3, ErrorMessage = "La description doit contenir au moins 3 caractères")]
		public string? Description { get; set; }
		[Required(ErrorMessage = "L'URL de l'image est requise")]
		public string? UrlPicture { get; set; }
		[Required(ErrorMessage = "Le prix est requis")]
		public Double Price { get; set; }
		[Required(ErrorMessage = "La quantité est requise")]
		[Range(0, 100, ErrorMessage = "La quantité doit être entre 0 et 100")]
		public int Quantity { get; set; }
		public string? Comments { get; set; }

		// Relationships
		public int TypeFurnitureId { get; set; }
		[ForeignKey(nameof(TypeFurnitureId))]
		public FurnitureType? TypeFurniture { get; set; }
	}
}
