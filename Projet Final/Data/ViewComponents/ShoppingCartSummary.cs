using Microsoft.AspNetCore.Mvc;
using Projet_Final.Data.Cart;

namespace Projet_Final.Data.ViewComponents
{
	public class ShoppingCartSummary : ViewComponent
	{
		private readonly ShoppingCart _shoppingCart;

		public ShoppingCartSummary(ShoppingCart shoppingCart)
		{
			_shoppingCart = shoppingCart;
		}

		//Cette méthode est appelée pour afficher le nombre d'articles dans le panier
		public IViewComponentResult Invoke()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			return View(items.Count);
		}
	}
}
