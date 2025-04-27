using Microsoft.EntityFrameworkCore;
using Projet_Final.Models;

namespace Projet_Final.Data.Cart
{
	public class ShoppingCart
	{
		public AppDbContext _context { get; set; }
		public string? ShoppingCartId { get; set; }
		public List<ShoppingCartItem> ShoppingCartItems { get; set; }

		public ShoppingCart(AppDbContext context)
		{
			_context = context;
		}

		//Configurations de la session du shoppingCart
		//Cette méthode statique permet de retrouver ou créer
		//un panier d'achat unique stockée en session
		//pour un utilisateur à partir du contexte HTTP 
		public static ShoppingCart GetShoppingCart(IServiceProvider services) //Récupérer une instance du panier d'achat
		{
			//Récupération de la session avec injection dépendance pour obtenir un accès au contexte HTTP courant
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			//Récupération du contexte de la base de données pour lire/ecrire les items du panier dans la base
			var context = services.GetService<AppDbContext>();

			//Lecture ou création d'un ID de panier à partir de la session,
			//si cet ID n'existe pas encore on crée un nouvel identifiant unique
			string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

			//Sauvegarde de l'ID dans la session  
			session.SetString("CartId", cartId);

			return new ShoppingCart(context) { ShoppingCartId = cartId };
		}

		//Méthode pour récupérer tous les éléments du panier
		public List<ShoppingCartItem> GetShoppingCartItems()
		{
			//Vérifie si la liste des articles est chargée,si c'est null la partie à droite est exécuté
			return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Furniture).ToList());
		}

		//Méthode pour avoir le total des articles
		public double GetShoppingCartTotal()
		{
			var total = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId)
												  .Select(n => n.Furniture.Price * n.Amount).Sum();
			return total;
		}

		//Ajout des articles dans le panier
		public void AddItemToCart(Furniture furniture)
		{
			//Recherche d'une furniture existante dans le panier
			var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Furniture.Id == furniture.Id && n.ShoppingCartId == ShoppingCartId);
			//si la furniture n'existe pas encore dans le panier créer un nouvel article
			if (shoppingCartItem == null)
			{
				shoppingCartItem = new ShoppingCartItem()
				{
					ShoppingCartId = ShoppingCartId,  //Associe l'article au panier actuel
					Furniture = furniture,  //Associe la furniture passée en paramètre à l'article
					Amount = 1     //initialise la quantité à 1 puisque l'article vient d'être ajouté

				};
				_context.ShoppingCartItems.Add(shoppingCartItem);
			}
			else
			{
				shoppingCartItem.Amount++;  //si l'article existe déjà dans le panier augmenter la quantité de 1
			}
			_context.SaveChanges();
		}

		//Retirer un article du panier
		public void RemoveItemFromCart(Furniture furniture)
		{
			//Recherche d'une furniture existante dans le panier
			var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Furniture.Id == furniture.Id && n.ShoppingCartId == ShoppingCartId);
			if (shoppingCartItem != null)
			{
				if (shoppingCartItem.Amount > 1)
				{
					shoppingCartItem.Amount--;
				}
				else
				{
					_context.ShoppingCartItems.Remove(shoppingCartItem);
				}

			}
			_context.SaveChanges();
		}

		//Méthode pour nettoyer le panier après exécution du paiement
		public async Task ClearShoppingCartAsync()
		{
			var items = await _context.ShoppingCartItems
				.Where(n => n.ShoppingCartId == ShoppingCartId)
				.ToListAsync();

			_context.ShoppingCartItems.RemoveRange(items);
			await _context.SaveChangesAsync();
		}
	}
}
