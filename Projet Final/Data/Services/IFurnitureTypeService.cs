using Projet_Final.Models;

namespace Projet_Final.Data.Services
{
	public interface IFurnitureTypeService
	{
		Task<IEnumerable<FurnitureType>> GetAllAsync();
		Task<FurnitureType> GetByIdAsync(int id);
		Task<bool> AddNewAsync(FurnitureType furnitureType);
		Task<FurnitureType> UpdateAsync(int id, FurnitureType furnitureType);
		Task DeleteAsync(int id);
	}
}
