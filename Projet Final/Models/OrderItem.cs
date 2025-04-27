using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_Final.Models
{
	public class OrderItem
	{
		[Key]
		public int Id { get; set; }
		public int Amount { get; set; }
		public double Price { get; set; }

		public int FurnitureId { get; set; }
		[ForeignKey(nameof(FurnitureId))]
		public virtual Furniture Furniture { get; set; }
		public int OrderId { get; set; }
		[ForeignKey(nameof(OrderId))]
		public virtual Order Order { get; set; }
	}
}
