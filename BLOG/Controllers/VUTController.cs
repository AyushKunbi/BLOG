using BLOG.Data;
using BLOG.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace BLOG.Controllers
{
    public class VUTController : Controller
    {
        private readonly UT QT;
        public VUTController(UT QT)
        {
            this.QT = QT;
        }
        

        public async Task<IActionResult> Approved()
        {
           var alist= await QT.UThought.Where(t => t.Status == 1).ToListAsync();
            return View(alist);
        }
        public async Task<IActionResult> ViewMe()
        {
            if (HttpContext.Session.GetString("AViewer") == null) { return RedirectToAction("Approved"); }

            var Tlist = await QT.UThought.Where(t => t.Status == 0).ToListAsync();

            string data = "No Items";
            TempData["Tdata"] = data;
            return View(Tlist);


        }
        [HttpPost]
        public async Task<IActionResult> Actions(Guid id)
        {
            if (HttpContext.Session.GetString("AViewer") == null) { return RedirectToAction("Approved"); }
            string btn = Request.Form["check"];
            if (btn == "Approve") 
            {
                var ap=await QT.UThought.FirstOrDefaultAsync(u=> u.Id==id);
                if (ap != null)
                {
                    ap.Status = 1;
                    ap.StatusMessage = "Approved";
                    await QT.SaveChangesAsync();
                    return RedirectToAction ("ViewMe", await QT.UThought.ToListAsync());
                }
            
            }
            else 
            {
                var ap = await QT.UThought.FirstOrDefaultAsync(u => u.Id == id);
                if (ap != null)
                {
                    ap.Status = 2;
                    ap.StatusMessage = "Rejected";
                    await QT.SaveChangesAsync();
                    return RedirectToAction("ViewMe", await QT.UThought.ToListAsync());

                }
            }
            return RedirectToAction("ViewMe", await QT.UThought.ToListAsync());


        }
    }
}
