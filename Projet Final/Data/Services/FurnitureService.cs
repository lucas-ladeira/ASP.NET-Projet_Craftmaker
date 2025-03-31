using Microsoft.EntityFrameworkCore;
using Projet_Final.Models;

namespace Projet_Final.Data.Services
{
	public class FurnitureService : IFurnitureService
	{
		private readonly AppDbContext _context;

		public FurnitureService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<bool> AddFurnitureAsync(Furniture furniture)
		{
			bool existingFurniture = await _context.Furnitures.AnyAsync(f => f.Id == furniture.Id);
			if (existingFurniture)
			{
				return false;
			}
			_context.Furnitures.Add(furniture);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task DeleteFurnitureAsync(int id)
		{
			var result = await _context.Furnitures.FirstOrDefaultAsync(f => f.Id == id);
			if (result != null)
			{
				_context.Furnitures.Remove(result);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Furniture>> GetAllFurnituresAsync()
		{
			var result = await _context.Furnitures
				.OrderBy(f => f.Name)
				.Include(t => t.TypeFurniture)
				.ToListAsync();
			return result;
		}

		public async Task<IEnumerable<FurnitureType>> GetAllFurnitureTypesAsync()
		{
			var result = await _context.FurnitureTypes.OrderBy(t => t.Id).ToListAsync();
			return result;
		}

		public async Task<Furniture> GetFurnitureByIdAsync(int id)
		{
			var result = await _context.Furnitures
				.Include(t => t.TypeFurniture)
				.FirstOrDefaultAsync(f => f.Id == id);
			return result;
		}

		public async Task<Furniture> UpdateFurnitureAsync(int id, Furniture furniture)
		{
			var result = await _context.Furnitures.FirstOrDefaultAsync(f => f.Id == id);
			if (result != null)
			{
				result.Name = furniture.Name;
				result.Description = furniture.Description;
				result.UrlPicture = furniture.UrlPicture;
				result.Price = furniture.Price;
				result.Comments = furniture.Comments;
				result.TypeFurnitureId = furniture.TypeFurnitureId;
				await _context.SaveChangesAsync();
			}
			return result;
		}
	}
}
