using Projet_Final.Models;

namespace Projet_Final.Data.Services
{
	public interface IFurnitureService
	{
		Task<IEnumerable<Furniture>> GetAllFurnituresAsync();
		Task<Furniture> GetFurnitureByIdAsync(int id);
		Task<bool> AddFurnitureAsync(Furniture furniture);
		Task<Furniture> UpdateFurnitureAsync(int id, Furniture furniture);
		Task DeleteFurnitureAsync(int id);
	}
}
