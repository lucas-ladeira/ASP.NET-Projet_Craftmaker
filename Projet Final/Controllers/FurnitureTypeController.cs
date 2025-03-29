using Microsoft.AspNetCore.Mvc;
using Projet_Final.Data.Services;
using Projet_Final.Models;

namespace Projet_Final.Controllers
{
	public class FurnitureTypeController : Controller
	{
		private readonly IFurnitureTypeService _service;

		public FurnitureTypeController(IFurnitureTypeService service)
		{
			_service = service;
		}

		// GET: FurnitureType/
		public async Task<IActionResult> Index()
		{
			// Récupérer la liste des types de meubles
			IEnumerable<FurnitureType> furnitureTypes = await _service.GetAllFurnitureTypeAsync();
			return View(furnitureTypes);
		}

		// GET: FurnitureType/Details/1
		public async Task<IActionResult> Details(int id)
		{
			FurnitureType furnitureType = await _service.GetFurnitureTypeByIdAsync(id);
			return View(furnitureType);
		}

		// GET: FurnitureType/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: FurnitureType/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name")] FurnitureType furnitureType)
		{
			if (ModelState.IsValid)
			{
				if (!await _service.AddFurnitureTypeAsync(furnitureType))
				{
					ModelState.AddModelError("Name", "Le type de meuble existe déjà");
					return View(furnitureType);
				}
				return RedirectToAction(nameof(Index));
			}
			return View(furnitureType);
		}

		// GET: FurnitureType/Edit/1
		public async Task<IActionResult> Edit(int id)
		{
			var furnitureType = await _service.GetFurnitureTypeByIdAsync(id);
			if (furnitureType == null) return View("NotFound");
			return View(furnitureType);
		}

		// POST: FurnitureType/Edit/1
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] FurnitureType furnitureType)
		{
			if (!ModelState.IsValid)
			{
				return View(furnitureType);
			}
			await _service.UpdateFurnitureTypeAsync(id, furnitureType);
			return RedirectToAction(nameof(Index));
		}

		// GET: FurnitureType/Delete/1
		public async Task<IActionResult> Delete(int id)
		{
			var furnitureType = await _service.GetFurnitureTypeByIdAsync(id);
			if (furnitureType == null) return View("NotFound");
			return View(furnitureType);
		}

		// POST: FurnitureType/Delete/1
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var furnitureType = await _service.GetFurnitureTypeByIdAsync(id);
			if (furnitureType == null) return View("NotFound");
			await _service.DeleteFurnitureTypeAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
