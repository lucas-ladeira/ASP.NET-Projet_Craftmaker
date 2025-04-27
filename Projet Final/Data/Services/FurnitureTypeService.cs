using Microsoft.EntityFrameworkCore;
using Projet_Final.Models;

namespace Projet_Final.Data.Services
{
	public class FurnitureTypeService : IFurnitureTypeService
	{
		private readonly AppDbContext _context;

		public FurnitureTypeService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<bool> AddNewAsync(FurnitureType furnitureType)
		{
			bool existingFurniture = await _context.FurnitureTypes.AnyAsync(t => t.Id == furnitureType.Id);
			if (existingFurniture)
			{
				return false;
			}
			_context.FurnitureTypes.Add(furnitureType);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task DeleteAsync(int id)
		{
			var result = await _context.FurnitureTypes.FirstOrDefaultAsync(t => t.Id == id);
			if (result != null)
			{
				_context.FurnitureTypes.Remove(result);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<FurnitureType>> GetAllAsync()
		{
			var result = await _context.FurnitureTypes
				.Include(t => t.Furnitures)
				.OrderBy(t => t.Name).ToListAsync();
			return result;
		}

		public async Task<FurnitureType> GetByIdAsync(int id)
		{
			var result = await _context.FurnitureTypes.FirstOrDefaultAsync(t => t.Id == id);
			return result;
		}

		public async Task<FurnitureType> UpdateAsync(int id, FurnitureType furnitureType)
		{
			var result = await _context.FurnitureTypes.FirstOrDefaultAsync(t => t.Id == id);
			if (result != null)
			{
				result.Name = furnitureType.Name;
				await _context.SaveChangesAsync();
			}
			return result;
		}
	}
}
