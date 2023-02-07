using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ThAmCo_Commerce.Data;
using ThAmCo_Commerce.Data.ViewModels;
using ThAmCo_Commerce.Models;
using ThAmCo_Commerce.Data.Static;


namespace ThAmCo_Commerce.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        /*public IActionResult Login() 
        { 
            var response = new LoginVM();
            return View(response); 
        }*/

        

        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);
            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This Email adress already has an account";
                return View(registerVM);
            }

            var newAccount = new AppUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.FullName
            };
            var newAccountResponse = await _userManager.CreateAsync(newAccount, registerVM.Password);

            if (newAccountResponse.Succeeded)            
                await _userManager.AddToRoleAsync(newAccount, UserRoles.User);
            return View("AccountCreated");

            
        }

        // Test
        /*[HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            string debug;
            if (!ModelState.IsValid) return View(loginVM);
            debug = "1";
            var user = await _userManager.FindByNameAsync(loginVM.EmailAddress);
            debug = "2";
            if (user != null)
            {
                debug = "3";
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    debug = "4";
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        debug = "5";
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        debug = "6";
                    }
                }
                else
                {
                    debug = passwordCheck.ToString();
                }
            }
            else
            {
                debug = loginVM.EmailAddress; 
            }

            TempData["Error"] = debug;
            return View(loginVM);

        }
    }*/
        //}

        public IActionResult Login() => View(new LoginVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Product");
                    }
                }
                TempData["Error"] = "Incorrect Email or password, please try again!";
                return View(loginVM);
            }

            TempData["Error"] = loginVM.EmailAddress;
            return View(loginVM);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Product");
        }
    }
}



