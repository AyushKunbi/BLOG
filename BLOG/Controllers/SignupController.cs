using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BLOG.Models;
using BLOG.Data;

namespace BLOG.Controllers
{
    public class SignupController : Controller
    {
        private readonly User UserVar;
        private readonly Creator CreatorVar;

        public SignupController(User UserVar, Creator CreatorVar)
        {
            this.UserVar = UserVar;
            this.CreatorVar = CreatorVar;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult UserSignUp()   
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserSignUp(SignUser usr)
        {
            //var check = await UserVar.Users.FirstOrDefaultAsync(n=>n.Email == usr.Email);
            //if (check ==null) 
            //{

            //}

            var SUuser = new UserModel()
            {
                ID = Guid.NewGuid(),
                FName = usr.FName,
                LName = usr.LName,
                Email = usr.Email,
                Password = usr.Password,

            };
            await UserVar.Users.AddAsync(SUuser);
            await UserVar.SaveChangesAsync();
            TempData["msg"] = "Record Inserted..";
            return RedirectToAction("UserLogin", "Login");


        }

        [HttpGet]
        public IActionResult CreatorSignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatorSignUp(SignCreator ctr)
        {

            var SUcreator = new CreatorModel()
            {
                ID = Guid.NewGuid(),
                FName = ctr.FName,
                LName = ctr.LName,
                Email = ctr.Email,
                Password = ctr.Password,

            };
            await CreatorVar.Creators.AddAsync(SUcreator);
            await CreatorVar.SaveChangesAsync();
            TempData["msg"] = "Record Inserted..";
            return RedirectToAction("CreatorSignUp");


        }
    }
}
