using Microsoft.AspNetCore.Mvc;
using PlantNest_Contest_E_Azam.Models;

namespace PlantNest_Contest_E_Azam.Controllers
{
	public class AdminController : Controller
	{
		private myContext _manicontext;
		private IWebHostEnvironment _env;
		public AdminController(myContext mycontext, IWebHostEnvironment env)
        {
            _manicontext = mycontext;
			_env = env;
        }
		public IActionResult Index()
		{
			var admin = HttpContext.Session.GetString("admin_session");
			if (admin != null)
			{
				return View();
			}
			else
			{
				return RedirectToAction("login");
			}

		}
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Login(string adminEmail, string adminPassword)
		{
			var row = _manicontext.tbl_admin.FirstOrDefault(a => a.admin_email == adminEmail);
			if (row != null && row.admin_password == adminPassword)
			{
				HttpContext.Session.SetString("admin_session", row.admin_id.ToString());
				return View("Index");
			}
			else
			{
				ViewBag.message = "Incorrect Username Or Password";
				return View();
			}

		}
		public IActionResult Logout()
		{
			HttpContext.Session.Remove("admin_session");
			return RedirectToAction("login");
		}
        public IActionResult Profile()
        {
            var admin = HttpContext.Session.GetString("admin_session");
            if (admin != null)
            {
                var adm = HttpContext.Session.GetString("admin_session");
                var data = _manicontext.tbl_admin.Where(a => a.admin_id == int.Parse(adm)).ToList();
                return View(data);
            }
            else
            {
                return RedirectToAction("login");
            }

        }
        [HttpPost]
        public IActionResult Profile(Admin admin)
        {
            _manicontext.tbl_admin.Update(admin);
            _manicontext.SaveChanges();
            return RedirectToAction("profile");
        }
        [HttpPost]
        public IActionResult ChangeProfileImage(IFormFile admin_image, Admin admin)
        {
            string ImagePath = Path.Combine(_env.WebRootPath, "AdminImages", admin_image.FileName);
            using (FileStream fs = new FileStream(ImagePath, FileMode.Create))
            {
                admin_image.CopyTo(fs);
            }
            admin.admin_image = admin_image.FileName;
            _manicontext.tbl_admin.Update(admin);
            _manicontext.SaveChanges();
            return RedirectToAction("profile");
        }
    }
}
