using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BLOG.Models;
using BLOG.Data;

namespace BLOG.Controllers
{
    public class UTController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly UT Thgt;
        public UTController(UT Thgt)
        {
            this.Thgt = Thgt;
        }
        [HttpGet]
        public IActionResult Add()
        {
            if (HttpContext.Session.GetString("UViewer") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddUT uth)
        {
            var thought = new UserThoughts()
            {
                Id = Guid.NewGuid(),
                Name = HttpContext.Session.GetString("UViewer"),
                UserId = Guid.Parse(HttpContext.Session.GetString("UID")),
                Title = uth.Title,
                Description = uth.Description,
                CreatedAt = DateTime.Now,
                Status = 0,
                StatusMessage = "Pending"

            };
            //var BGUID = Kontent.ID;
            //HttpContext.Session.SetString("gid", BGUID.ToString());

            await Thgt.UThought.AddAsync(thought);
            await Thgt.SaveChangesAsync();
            return RedirectToAction("Cview", "ViewContent");
        }

    }
}
