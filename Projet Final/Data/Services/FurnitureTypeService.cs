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

		public async Task<bool> AddFurnitureTypeAsync(FurnitureType furnitureType)
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

		public async Task DeleteFurnitureTypeAsync(int id)
		{
			var result = await _context.FurnitureTypes.FirstOrDefaultAsync(t => t.Id == id);
			if (result != null)
			{
				_context.FurnitureTypes.Remove(result);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<FurnitureType>> GetAllFurnitureTypeAsync()
		{
			var result = await _context.FurnitureTypes.OrderBy(t => t.Name).ToListAsync();
			return result;
		}

		public async Task<FurnitureType> GetFurnitureTypeByIdAsync(int id)
		{
			var result = await _context.FurnitureTypes.FirstOrDefaultAsync(t => t.Id == id);
			return result;
		}

		public async Task<FurnitureType> UpdateFurnitureTypeAsync(int id, FurnitureType furnitureType)
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
