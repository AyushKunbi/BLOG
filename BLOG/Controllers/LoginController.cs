using Microsoft.AspNetCore.Mvc;
using BLOG.Models;
using BLOG.Data;
using Microsoft.EntityFrameworkCore;


namespace BLOG.Controllers
{
    public class LoginController : Controller
    {

        private readonly User User_LVar;
        private readonly Creator Creator_LVar;
        public LoginController(User User_LVar, Creator Creator_LVar)
        {
            this.User_LVar = User_LVar;
            this.Creator_LVar = Creator_LVar;
        }



        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(LogUser model)
        {

            var details = await User_LVar.Users.FirstOrDefaultAsync(n => n.Email == model.Email && n.Password == model.Password);
            if (details != null)
            {
                var FullName = details.FName + " " + details.LName;
                HttpContext.Session.SetString("UViewer", FullName);
                HttpContext.Session.SetString("UID", details.ID.ToString());
                

                return RedirectToAction("CView", "ViewContent");
            }
            TempData["Invalid_Msg"] = "Invalid Details";
            return View("UserLogin");
        }

        [HttpGet]
        public IActionResult CreatorLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatorLogin(LogCreator model)
        {
            var details = await Creator_LVar.Creators.FirstOrDefaultAsync(n => n.Email == model.Email && n.Password == model.Password);
            if (details != null)
            {
                //if (await Creator_LVar.Creators.Where(n => n.Email == model.Email).CountAsync() > 1)
                //{
                //    TempData["Invalid_Msg"] = "Email Already Used"; // add tempdata in placeholder in red color
                //    return View("CreatorLogin");
                //}
                // var AFullName=model.FName +" "+ model.LName;
                var FullName = details.FName + " " + details.LName;
                HttpContext.Session.SetString("AViewer", FullName);
             
               
                return RedirectToAction("CAdd","AddContent");
            }
            TempData["Invalid_Msg"] = "Invalid Details";
            return View("CreatorLogin");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AViewer");
            HttpContext.Session.Remove("UViewer");
            return RedirectToAction("Index", "Home");
        }


    }
}
