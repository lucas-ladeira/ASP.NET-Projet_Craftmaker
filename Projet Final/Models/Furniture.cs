using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_Final.Models
{
	public class Furniture
	{
		// Properties
		[Key]
		public int Id { get; set; }

		[Display(Name = "Nom")]
		[Required(ErrorMessage = "Le nom est requis")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Le nom doit contenir au moins 3 caractères")]
		public string? Name { get; set; }

		[Required(ErrorMessage = "La description est requise")]
		[StringLength(255, MinimumLength = 3, ErrorMessage = "La description doit contenir au moins 3 caractères")]
		public string? Description { get; set; }

		[Display(Name = "Image")]
		[Required(ErrorMessage = "L'URL de l'image est requise")]
		public string? UrlPicture { get; set; }

		[Display(Name = "Prix")]
		[Required(ErrorMessage = "Le prix est requis")]
		public Double Price { get; set; }

		[Display(Name = "Commentaires")]
		public string? Comments { get; set; }

		// Relationships
		[Display(Name ="Type de meuble")]
		public int TypeFurnitureId { get; set; }

		[Display(Name = "Type")]
		[ForeignKey(nameof(TypeFurnitureId))]
		public FurnitureType? TypeFurniture { get; set; }
	}
}
