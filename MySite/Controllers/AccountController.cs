using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MySite.Domain.Entities;
using System.Threading.Tasks;

namespace MySite.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<ApplicationUser> userMgr, SignInManager<ApplicationUser> signinMgr, RoleManager<IdentityRole> roleMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
            roleManager = roleMgr;
        }


        public async Task<IdentityResult> CreateUserAsync(SignUpUser userModel)
        {
            var user = new ApplicationUser()
            {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                //Post=userModel.Post,
                Email = userModel.Email,
                UserName = userModel.Email

            };

           return await userManager.CreateAsync(user, userModel.Password);
            
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> PasswordSignInAsync(SignIn signInModel)
        {
            return await signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, signInModel.RememberMe, false);
        }


        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }


       
        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUser userModel)
        {
            if (ModelState.IsValid)
            {
                
                var result = await CreateUserAsync(userModel);
                if (!result.Succeeded)
                {
                   

                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }

                    return View(userModel);
                }
                
                ModelState.Clear();
               
            }

            return View();
        }

       
        [Route("login")]
        public  IActionResult Login()
        {
           
             return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignIn signInModel)
        {
           // string message="";
            if (ModelState.IsValid)
            {
                var result = await PasswordSignInAsync(signInModel);
                if (result.Succeeded)
                {

                    if (User.IsInRole("Manager"))
                    {
                        return RedirectToAction("Manager", "Home");
                    }

                    else if(User.IsInRole("Technologist"))
                    {
                        return RedirectToAction("Technologist", "Home");
                    }

                    else if (User.IsInRole("PurAgent"))
                    {
                        return RedirectToAction("PurAgent", "Home");
                    }

                    else if (User.IsInRole("Accountant"))
                    {
                        return RedirectToAction("Accountant", "Home");
                    }

                    else if (User.IsInRole("Admin"))
                    {
                        return RedirectToAction("Admin", "Home");
                    }

                   // else message ="У пользователя нет права доступа";

                }
                //if (message == "")
                //{
                //    ModelState.AddModelError("", "Некорректные данные");
                //}
                //else ModelState.AddModelError("", message);



            }
            return View(signInModel);
        }


        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
