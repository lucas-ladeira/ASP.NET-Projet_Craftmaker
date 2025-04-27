using Microsoft.EntityFrameworkCore;
using Projet_Final.Models;

namespace Projet_Final.Data.Services
{
	public class OrdersService : IOrdersService
	{
		private readonly AppDbContext _context;

		public OrdersService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId)
		{
			var orders = await _context.Orders
				.Include(n => n.OrderItems)
				.ThenInclude(n => n.Furniture)
				.Where(n => n.UserId == userId)
				.ToListAsync();

			return orders;
		}

		public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
		{
			var order = new Order()
			{
				UserId = userId,
				Email = userEmailAddress
			};
			await _context.Orders.AddAsync(order);
			await _context.SaveChangesAsync();

			foreach (var item in items)
			{
				var orderItem = new OrderItem()
				{
					Amount = item.Amount,
					FurnitureId = item.Furniture.Id,
					OrderId = order.Id,
					Price = item.Furniture.Price
				};
				await _context.OrderItems.AddAsync(orderItem);
			}
			await _context.SaveChangesAsync();
		}
	}
}
