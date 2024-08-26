using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlantNest_Contest_E_Azam.Models;

namespace PlantNest_Contest_E_Azam.Controllers
{
	public class AdminController : Controller
	{
		private myContext _mycontext;
		private IWebHostEnvironment _env;
		public AdminController(myContext mycontext, IWebHostEnvironment env)
        {
            _mycontext = mycontext;
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
			var row = _mycontext.tbl_admin.FirstOrDefault(a => a.admin_email == adminEmail);
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
                var data = _mycontext.tbl_admin.Where(a => a.admin_id == int.Parse(adm)).ToList();
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
            _mycontext.tbl_admin.Update(admin);
            _mycontext.SaveChanges();
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
            _mycontext.tbl_admin.Update(admin);
            _mycontext.SaveChanges();
            return RedirectToAction("profile");
        }
        public IActionResult FetchUsers()
        {
            var admin = HttpContext.Session.GetString("admin_session");
            if (admin != null)
            {
                return View(_mycontext.tbl_user.ToList());

            }
            else
            {
                return RedirectToAction("login");
            }
        }
        public IActionResult DetailUsers(int id)
        {
            return View(_mycontext.tbl_user.FirstOrDefault(u => u.user_id== id));
        }
        public IActionResult UpdateUser(int id)
        {
            return View(_mycontext.tbl_user.Find(id));
        }
        [HttpPost]
        public IActionResult UpdateUser(User user, IFormFile user_image)
        {
            string ImagePath = Path.Combine(_env.WebRootPath, "UserImages", user_image.FileName);
            using (FileStream fs = new FileStream(ImagePath, FileMode.Create))
            {
                user_image.CopyTo(fs);
            }
            user.user_image = user_image.FileName;
            _mycontext.tbl_user.Update(user);
            _mycontext.SaveChanges();
            return RedirectToAction("FetchUsers");
        }

        public IActionResult DeleteUser(int id)
        {
            var customer = _mycontext.tbl_user.Find(id);
            _mycontext.tbl_user.Remove(customer);
            _mycontext.SaveChanges();
            return RedirectToAction("FetchUsers");
        }
        public IActionResult FetchCategory()
        {
            var admin = HttpContext.Session.GetString("admin_session");
            if (admin != null)
            {
                return View(_mycontext.tbl_category.ToList());
            }
            else
            {
                return RedirectToAction("login");
            }
        }

        public IActionResult AddCategory()
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
        [HttpPost]

        public IActionResult AddCategory(Category category)
        {
            _mycontext.tbl_category.Add(category);
            _mycontext.SaveChanges();
            return RedirectToAction("FetchCategory");

        }

        public IActionResult UpdateCategory(int id)
        {
            var admin = HttpContext.Session.GetString("admin_session");
            if (admin != null)
            {
                return View(_mycontext.tbl_category.Find(id));
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        [HttpPost]
        public IActionResult UpdateCategory(Category cat)
        {
            _mycontext.tbl_category.Update(cat);
            _mycontext.SaveChanges();
            return RedirectToAction("FetchCategory");
        }

        public IActionResult DeleteCategory(int id)
        {
            var category = _mycontext.tbl_category.Find(id);
            _mycontext.tbl_category.Remove(category);
            _mycontext.SaveChanges();
            return RedirectToAction("FetchCategory");
        }
        public IActionResult FetchFeedback()
        {
            var admin = HttpContext.Session.GetString("admin_session");
            if (admin != null)
            {
                return View(_mycontext.tbl_feedback.ToList());
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        public IActionResult DeleteFeedback(int id)
        {
            var feedback = _mycontext.tbl_feedback.Find(id);
            _mycontext.tbl_feedback.Remove(feedback);
            _mycontext.SaveChanges();
            return RedirectToAction("FetchFeedback");
        }
        public IActionResult FetchReviews()
        {
            var admin = HttpContext.Session.GetString("admin_session");
            if (admin != null)
            {
                return View(_mycontext.tbl_review.ToList());
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        public IActionResult DeleteReviews(int id)
        {
            var review = _mycontext.tbl_review.Find(id);
            _mycontext.tbl_review.Remove(review);
            _mycontext.SaveChanges();
            return RedirectToAction("FetchReviews");
        }
        public IActionResult FetchPlants()
        {
            var admin = HttpContext.Session.GetString("admin_session");
            if (admin != null)
            {
                return View(_mycontext.tbl_plant.ToList());
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        public IActionResult DetailPlant(int id)
        {
            return View(_mycontext.tbl_plant.Include(p => p.categories).FirstOrDefault
                (p => p.plant_id == id));
        }
        public IActionResult AddPlant()
        {
            var admin = HttpContext.Session.GetString("admin_session");
            if (admin != null)
            {
                List<Category> categories = _mycontext.tbl_category.ToList();
                ViewData["category"] = categories;
                return View();
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        [HttpPost]
        public IActionResult AddPlant(Plant plant, IFormFile plant_image)
        {
            string ImageName = Path.GetFileName(plant_image.FileName);
            string ImagePath = Path.Combine(_env.WebRootPath, "PlantImages", ImageName);
            using (FileStream fs = new FileStream(ImagePath, FileMode.Create))
            {
                plant_image.CopyTo(fs);
            }
            plant.plant_image = ImageName;
            _mycontext.tbl_plant.Add(plant);
            _mycontext.SaveChanges();
            return RedirectToAction("FetchPlants");
        }

        public IActionResult UpdatePlant(int id)
        {
            List<Category> categories = _mycontext.tbl_category.ToList();
            ViewData["category"] = categories;

            var plant = _mycontext.tbl_plant.Find(id);
            ViewBag.SelectedCategoryId = plant.category_id;
            return View(plant);
        }
        [HttpPost]
        public IActionResult UpdatePlant(IFormFile plant_image, Plant plant)
        {
            string ImagePath = Path.Combine(_env.WebRootPath, "PlantImages", plant_image.FileName);

            using (FileStream fs = new FileStream(ImagePath, FileMode.Create))
            {
                plant_image.CopyTo(fs);
            }

            plant.plant_image = plant_image.FileName;

            _mycontext.tbl_plant.Update(plant);
            _mycontext.SaveChanges();
            return RedirectToAction("FetchPlants");
        }
        public IActionResult DeletePlant(int id)
        {
            var product = _mycontext.tbl_plant.Find(id);
            _mycontext.tbl_plant.Remove(product);
            _mycontext.SaveChanges();
            return RedirectToAction("FetchPlants");
        }
        public IActionResult FetchAccessory()
        {
            var admin = HttpContext.Session.GetString("admin_session");
            if (admin != null)
            {
                return View(_mycontext.tbl_accessory.ToList());
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        public IActionResult DetailAccessory(int id)
        {
            var accessory = _mycontext.tbl_accessory.Find(id);
            return View(accessory);
        }
        public IActionResult AddAccessory()
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
        [HttpPost]
        public IActionResult AddAccessory(Accessory accessory, IFormFile accessory_image)
        {
            string ImageName = Path.GetFileName(accessory_image.FileName);
            string ImagePath = Path.Combine(_env.WebRootPath, "AccessoryImages", ImageName);
            using (FileStream fs = new FileStream(ImagePath, FileMode.Create))
            {
                accessory_image.CopyTo(fs);
            }
            accessory.accessory_image = ImageName;
            _mycontext.tbl_accessory.Add(accessory);
            _mycontext.SaveChanges();
            return RedirectToAction("FetchAccessory");
        }

        public IActionResult UpdateAccessory(int id)
        {
            var accessory = _mycontext.tbl_accessory.Find(id);
            return View(accessory);
        }
        [HttpPost]
        public IActionResult UpdateAccessory(IFormFile accessory_image, Accessory accessory)
        {
            string ImagePath = Path.Combine(_env.WebRootPath, "AccessoryImages", accessory_image.FileName);

            using (FileStream fs = new FileStream(ImagePath, FileMode.Create))
            {
                accessory_image.CopyTo(fs);
            }

            accessory.accessory_image = accessory_image.FileName;

            _mycontext.tbl_accessory.Update(accessory);
            _mycontext.SaveChanges();
            return RedirectToAction("FetchAccessory");
        }
        public IActionResult DeleteAccessory(int id)
        {
            var accessory = _mycontext.tbl_accessory.Find(id);
            _mycontext.tbl_accessory.Remove(accessory);
            _mycontext.SaveChanges();
            return RedirectToAction("FetchAccessory");
        }
    }
}
