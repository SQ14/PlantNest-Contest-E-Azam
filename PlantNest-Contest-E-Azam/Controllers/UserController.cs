using Microsoft.AspNetCore.Mvc;
using PlantNest_Contest_E_Azam.Models;

namespace PlantNest_Contest_E_Azam.Controllers
{
	public class UserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
