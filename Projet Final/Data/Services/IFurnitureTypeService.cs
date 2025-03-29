using Projet_Final.Models;

namespace Projet_Final.Data.Services
{
	public interface IFurnitureTypeService
	{
		Task<IEnumerable<FurnitureType>> GetAllFurnitureTypeAsync();
		Task<FurnitureType> GetFurnitureTypeByIdAsync(int id);
		Task<bool> AddFurnitureTypeAsync(FurnitureType furnitureType);
		Task<FurnitureType> UpdateFurnitureTypeAsync(int id, FurnitureType furnitureType);
		Task DeleteFurnitureTypeAsync(int id);
	}
}
