using Microsoft.AspNetCore.Mvc;
using Projet_Final.Data.Services;
using Projet_Final.Models;

namespace Projet_Final.Controllers
{
	public class FurnitureController : Controller
	{
		private readonly IFurnitureService _service;

		public FurnitureController(IFurnitureService service)
		{
			_service = service;
		}

		// GET: Furniture/
		public async Task<IActionResult> Index()
		{
			// Récupérer la liste des meubles
			IEnumerable<Furniture> furnitures = await _service.GetAllFurnituresAsync();
			return View(furnitures);
		}

		// GET: Furniture/Details/1
		public async Task<IActionResult> Details(int id)
		{
			var furniture = await _service.GetFurnitureByIdAsync(id);
			if (furniture == null) return View("NotFound");
			return View(furniture);
		}

		// GET: Furniture/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Furniture/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Description,UrlPicture,Price,Quantity,Comments,TypeFurnitureId")] Furniture furniture)
		{
			if (ModelState.IsValid)
			{
				if (!await _service.AddFurnitureAsync(furniture))
				{
					ModelState.AddModelError("Name", "Le meuble existe déjà");
					return View(furniture);
				}
				return RedirectToAction(nameof(Index));
			}
			return View(furniture);
		}

		// GET: Furniture/Edit/1
		public async Task<IActionResult> Edit(int id)
		{
			var furniture = await _service.GetFurnitureByIdAsync(id);
			if (furniture == null) return View("NotFound");
			return View(furniture);
		}

		// POST: Furniture/Edit/1
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,UrlPicture,Price,Quantity,Comments,TypeFurnitureId")] Furniture furniture)
		{
			if (!ModelState.IsValid)
			{
				return View(furniture);
			}
			await _service.UpdateFurnitureAsync(id, furniture);
			return RedirectToAction(nameof(Index));
		}

		// GET: Furniture/Delete/1
		public async Task<IActionResult> Delete(int id)
		{
			var furniture = await _service.GetFurnitureByIdAsync(id);
			if (furniture == null) return View("NotFound");
			return View(furniture);
		}

		// POST: Furniture/Delete/1
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var furniture = await _service.GetFurnitureByIdAsync(id);
			if (furniture == null) return View("NotFound");
			await _service.DeleteFurnitureAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
