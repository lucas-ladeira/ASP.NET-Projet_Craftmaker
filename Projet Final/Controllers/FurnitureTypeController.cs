using Microsoft.AspNetCore.Mvc;
using Projet_Final.Data.Services;

namespace Projet_Final.Controllers
{
	public class FurnitureTypeController : Controller
	{
		private readonly IFurnitureTypeService _service;
		public IActionResult Index()
		{
			return View();
		}
	}
}
