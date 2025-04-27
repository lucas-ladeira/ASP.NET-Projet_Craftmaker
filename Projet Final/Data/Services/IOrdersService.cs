using Projet_Final.Models;

namespace Projet_Final.Data.Services
{
	public interface IOrdersService
	{
		Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);
		Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId);
	}
}
