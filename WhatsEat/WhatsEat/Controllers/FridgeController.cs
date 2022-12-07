using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WhatsEat.Areas.Identity.Data;
using WhatsEat.ViewModel;

namespace WhatsEat.Controllers
{
    public class FridgeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        

        public FridgeController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
        }
        
        // GET: FridgeController
        public ActionResult Index()
        {
            UserFridgeViewModel fridgeVM = new UserFridgeViewModel();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            fridgeVM.UserId = userId;
            fridgeVM.Products = _context.Users.Where(u => u.Id == userId).FirstOrDefault().UserProducts.ToList();
            fridgeVM.ProductTypes = _context.ProductTypes.ToList();
            return View(fridgeVM);
        }

        // GET: FridgeController/AddProducts
        public ActionResult AddProducts()
        {
            return View();
        }

        // POST: FridgeController/AddProducts
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProducts(IFormCollection collection)
        {
           
             return View();
            
        }

        // GET: FridgeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FridgeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FridgeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FridgeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
