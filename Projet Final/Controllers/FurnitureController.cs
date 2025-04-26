using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projet_Final.Data.Services;
using Projet_Final.Models;

namespace Projet_Final.Controllers
{
	public class FurnitureController : Controller
	{
		private readonly IFurnitureService _service;
		private readonly IFurnitureTypeService _serviceType;

		public FurnitureController(IFurnitureService service, IFurnitureTypeService serviceType)
		{
			_service = service;
			_serviceType = serviceType;
		}

		// GET: Furniture/
		public async Task<IActionResult> Index()
		{
			// Récupérer la liste des meubles
			IEnumerable<Furniture> furnitures = await _service.GetAllAsync();
			return View(furnitures);
		}

		// GET: Furniture/Details/1
		public async Task<IActionResult> Details(int id)
		{
			var furniture = await _service.GetByIdAsync(id);
			if (furniture == null) return View("NotFound");
			return View(furniture);
		}

		// GET: Furniture/Create
		public async Task<IActionResult> Create()
		{
			IEnumerable<FurnitureType> types = await _serviceType.GetAllAsync();
			ViewBag.TypeFurnitureId = new SelectList(types, "Id", "Name");
			return View();
		}

		// POST: Furniture/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Description,UrlPicture,Price,Comments,TypeFurnitureId")] Furniture furniture)
		{
			if (ModelState.IsValid)
			{
				if (!await _service.AddNewAsync(furniture))
				{
					ModelState.AddModelError("Name", "Le meuble existe déjà");
					return View(furniture);
				}
				return RedirectToAction(nameof(Index));
			}
			var types = await _serviceType.GetAllAsync();
			ViewBag.TypeFurnitureId = new SelectList(types, "Id", "Name");
			return View(furniture);
		}

		// GET: Furniture/Edit/1
		public async Task<IActionResult> Edit(int id)
		{
			var furniture = await _service.GetByIdAsync(id);
			if (furniture == null) return View("NotFound");
			var types = await _serviceType.GetAllAsync();
			ViewBag.TypeFurnitureId = new SelectList(types, "Id", "Name");
			return View(furniture);
		}

		// POST: Furniture/Edit/1
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,UrlPicture,Price,Comments,TypeFurnitureId")] Furniture furniture)
		{
			if (!ModelState.IsValid)
			{
				var furnitureTypes = await _serviceType.GetAllAsync();
				ViewBag.TypeFurnitureId = new SelectList(furnitureTypes, "Id", "Name", furniture.TypeFurnitureId);
				return View(furniture);
			}
			await _service.UpdateAsync(id, furniture);
			var types = await _serviceType.GetAllAsync();
			ViewBag.TypeFurnitureId = new SelectList(types, "Id", "Name");
			return RedirectToAction(nameof(Index));
		}

		// GET: Furniture/Delete/1
		public async Task<IActionResult> Delete(int id)
		{
			var furniture = await _service.GetByIdAsync(id);
			if (furniture == null) return View("NotFound");
			return View(furniture);
		}

		// POST: Furniture/Delete/1
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var furniture = await _service.GetByIdAsync(id);
			if (furniture == null) return View("NotFound");
			await _service.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
