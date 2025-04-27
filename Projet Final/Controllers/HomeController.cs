using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Projet_Final.Data.Services;
using Projet_Final.Models;

namespace Projet_Final.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;
	private readonly IFurnitureService _service;

	public HomeController(ILogger<HomeController> logger, IFurnitureService service)
	{
		_logger = logger;
		_service = service;
	}

	public async Task<IActionResult> Filter(string searchString)
	{
		var allProducts = await _service.GetAllAsync();

		if (!string.IsNullOrEmpty(searchString))
		{
			searchString = searchString.ToLower();
			var filteredResult = allProducts.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower()));
			return View("Index", filteredResult);
		}
		return View("Index", allProducts);
	}

	// GET: Home
	public async Task<IActionResult> Index()
	{
		IEnumerable<Furniture> furnitures = await _service.GetAllAsync();
		return View(furnitures);
	}

	// GET: Home/Details/5
	public async Task<IActionResult> Details(int id)
	{
		var selectedFurniture = await _service.GetByIdAsync(id);
		if (selectedFurniture == null) return View("NotFound");
		return View(selectedFurniture);
	}

	public IActionResult Privacy()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
