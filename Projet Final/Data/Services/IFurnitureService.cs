using Projet_Final.Models;

namespace Projet_Final.Data.Services
{
	public interface IFurnitureService
	{
		Task<IEnumerable<Furniture>> GetAllAsync();
		Task<Furniture> GetByIdAsync(int id);
		Task<bool> AddNewAsync(Furniture furniture);
		Task<Furniture> UpdateAsync(int id, Furniture furniture);
		Task DeleteAsync(int id);
	}
}
