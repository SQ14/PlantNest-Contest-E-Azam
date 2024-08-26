using Microsoft.AspNetCore.Mvc;
using PlantNest_Contest_E_Azam.Migrations;
using PlantNest_Contest_E_Azam.Models;

namespace PlantNest_Contest_E_Azam.Controllers
{
	public class UserController : Controller
	{
        private myContext _mycontext;
        private IWebHostEnvironment _env;
        public UserController(myContext mycontext, IWebHostEnvironment env)
        {
            _mycontext = mycontext;
            _env = env;
        }
        public IActionResult Index()
		{
            List<Category> category = _mycontext.tbl_category.ToList();
            ViewData["category"] = category;

            List<Plant> plants = _mycontext.tbl_plant.ToList();
            ViewData["plant"] = plants;
            
            List<Accessory> accessory = _mycontext.tbl_accessory.ToList();
            ViewData["acccessories"] = accessory;

            ViewBag.checkSession = HttpContext.Session.GetString("userSession");
            return View();
		}
        public IActionResult UserLogin()
		{
			return View();
		}
        [HttpPost]
        public IActionResult UserLogin(string User_Email, string User_Password)
        {
            var user = _mycontext.tbl_user.FirstOrDefault(u => u.user_email == User_Email);
            if (user  != null && user.user_password == User_Password)
            {
                HttpContext.Session.SetString("userSession",
                    user.user_id.ToString());
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Incorrect Username Or Password";
                return View();
            }

        }
        public IActionResult UserRegistration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserRegistration(User user)
        {
            _mycontext.tbl_user.Add(user);
            _mycontext.SaveChanges();
            return RedirectToAction("UserLogin");
        }
        public IActionResult UserLogout()
        {
            HttpContext.Session.Remove("userSession");
            return RedirectToAction("Index");
        }
        public IActionResult FetchProfile(int id)
        {
            List<User> user = _mycontext.tbl_user.ToList();
            ViewData["user"] = user;
            var userId = HttpContext.Session.GetString("userSession");
            var data = _mycontext.tbl_user.Where(u => u.user_id == int.Parse(userId)).ToList();
            return View(data);
        }
        public IActionResult UserProfile()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("userSession")))
            {
                return RedirectToAction("UserLogin");
            }
            else
            {
                List<User> user  = _mycontext.tbl_user.ToList();
                ViewData["user"] = user;
                var userId = HttpContext.Session.GetString("userSession");
                var data = _mycontext.tbl_user.Where(u => u.user_id == int.Parse(userId)).ToList();
                return View(data);
            }
        }


        [HttpPost]
        public IActionResult UpdateUserProfile(IFormFile user_image, User user)
        {

            string ImagePath = Path.Combine(_env.WebRootPath, "UserImages", user_image.FileName);
            using (FileStream fs = new FileStream(ImagePath, FileMode.Create))
            {
                user_image.CopyTo(fs);
            }
            user.user_image = user_image.FileName;
            _mycontext.tbl_user.Update(user);
            _mycontext.SaveChanges();
            return RedirectToAction("UserProfile");
        }

        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            _mycontext.tbl_user.Update(user);
            _mycontext.SaveChanges();
            return RedirectToAction("UserProfile");
        }
        [HttpPost]
        public IActionResult DeleteUserProfile(int id)
        {
         var user = _mycontext.tbl_user.Find(id);
            _mycontext.tbl_user.Remove(user);
            HttpContext.Session.Remove("userSession");
            _mycontext.SaveChanges();
            return RedirectToAction("UserRegistration");
        }
        public IActionResult ShopPage()
        {
            List<Category> category = _mycontext.tbl_category.ToList();
            ViewData["category"] = category;

            List<Plant> plant = _mycontext.tbl_plant.ToList();
            ViewData["plant"] = plant;
            
            List<Accessory> accessory = _mycontext.tbl_accessory.ToList();
            ViewData["accessory"] = accessory;
            return View();
        }
        public IActionResult ShopDetailPage(int id)
        {
            List<Category> category = _mycontext.tbl_category.ToList();
            ViewData["category"] = category;
            List<Plant> plant = _mycontext.tbl_plant.ToList();
            ViewData["plant"] = plant;
            var plants = _mycontext.tbl_plant.Where(p => p.plant_id == id).ToList();
            return View(plants);
        }
        public IActionResult ShopDetailPageAccessory(int id)
        {
            List<Category> category = _mycontext.tbl_category.ToList();
            ViewData["category"] = category;
            List<Accessory> plant = _mycontext.tbl_accessory.ToList();
            ViewData["accessory"] = plant;
            var accessories = _mycontext.tbl_accessory.Where(a => a.accessory_id == id).ToList();
            return View(accessories);
        }
        public IActionResult ContactPage()
        {
            return View();
        }
        public IActionResult AboutPage()
        {
            return View();
        }
        public IActionResult BlogPage()
        {
            return View();
        }
        public IActionResult BlogDetailPage()
        {
            return View();
        }
        public IActionResult GalleryPage()
        {
            return View();
        }
        public IActionResult GalleryDetailPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddToCart(int plant_id, Cart cart)
        {
            string IsLogin = HttpContext.Session.GetString("userSession");
            if (IsLogin != null)
            {
                cart.plant_id = plant_id;
                cart.user_id = int.Parse(IsLogin);
                cart.plant_quantity = 1;
                cart.cart_status = "Pending";
                _mycontext.tbl_cart.Add(cart);
                _mycontext.SaveChanges();
                TempData["message"] = "Plant Successfully Added In Cart";
                return RedirectToAction("ShopPage");
            }
            return RedirectToAction("UserLogin");
        }
        public IActionResult ViewCartUser()
        {
            string UserId = HttpContext.Session.GetString("userSession");
            if (UserId != null)
            {
                var cart = _mycontext.tbl_cart.Where(u => u.user_id == int.Parse(UserId)).Include(p => p.plants).ToList(); 
                return View(cart);
            }
            else
            {
                return RedirectToAction("CustomerLogin");
            }
        }
        public IActionResult DeleteCart(int id)
        {
            var cart = _mycontext.tbl_cart.Find(id);
            _mycontext.tbl_cart.Remove(cart);
            _mycontext.SaveChanges();
            return RedirectToAction("PlantDetailPage");
        }
        [HttpPost]
        public IActionResult AddToCartAccessory(int accessory_id, Cart cart)
        {
            string IsLogin = HttpContext.Session.GetString("userSession");
            if (IsLogin != null)
            {
                cart.accessory_id = accessory_id;
                cart.user_id = int.Parse(IsLogin);
                cart.accessory_quantity = 1;
                cart.cart_status = "Pending";
                _mycontext.tbl_cart.Add(cart);
                _mycontext.SaveChanges();
                TempData["message"] = "Accessory Successfully Added In Cart";
                return RedirectToAction("ShopPage");
            }
            return RedirectToAction("UserLogin");
        }
        public IActionResult DeleteCartAccessory(int id)
        {
            var cart = _mycontext.tbl_cart.Find(id);
            _mycontext.tbl_cart.Remove(cart);
            _mycontext.SaveChanges();
            return RedirectToAction("PlantDetailPage");
        }
    }
}
