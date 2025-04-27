using Microsoft.AspNetCore.Mvc;
using Projet_Final.Data.Cart;
using Projet_Final.Data.Services;
using Projet_Final.Data.ViewModels;

namespace Projet_Final.Controllers
{
	public class OrdersController : Controller
	{
		private readonly IFurnitureService _furnitureService;
		private readonly IOrdersService _ordersService;
		private readonly ShoppingCart _shoppingCart;

		public OrdersController(IFurnitureService furnitureService, IOrdersService ordersService, ShoppingCart shoppingCart)
		{
			_furnitureService = furnitureService;
			_ordersService = ordersService;
			_shoppingCart = shoppingCart;
		}

		public IActionResult ShoppingCart()
		{
			//recupération de la liste des articles du panier
			var items = _shoppingCart.GetShoppingCartItems();
			//On assigne cette liste à la propriété qui sera utilisée pour l'affichage
			_shoppingCart.ShoppingCartItems = items;

			//On prépare une instance du modèle de vue,pour l'afficahge
			var response = new ShoppingCartVM()
			{
				ShoppingCart = _shoppingCart,    // l'ojet panier avec les articles
				ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()  //le total
			};
			return View(response);
		}

		// Méthode pour ajouter un article dans le panier  
		public async Task<IActionResult> AddItemToShoppingCart(int id)
		{
			var item = await _furnitureService.GetByIdAsync(id);
			if (item != null)
			{
				_shoppingCart.AddItemToCart(item);
			}
			return RedirectToAction(nameof(ShoppingCart));

		}

		//Méthode pour retirer un article dans le panier
		public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
		{
			var item = await _furnitureService.GetByIdAsync(id);
			if (item != null)
			{
				_shoppingCart.RemoveItemFromCart(item);
			}
			return RedirectToAction(nameof(ShoppingCart));

		}

		public async Task<IActionResult> CompleteOrder()
		{
			var items = _shoppingCart.GetShoppingCartItems();

			string userId = "";
			string userEmailAddress = "";

			await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);

			await _shoppingCart.ClearShoppingCartAsync();

			return View("OrderCompleted");
		}
	}
}
