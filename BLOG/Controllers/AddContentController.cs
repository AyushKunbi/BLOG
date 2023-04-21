using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BLOG.Models;
using BLOG.Data;


namespace BLOG.Controllers
{
    public class AddContentController : Controller
    {
        
        private readonly Content Add_Content;
        //private readonly Creator Creator_CVar;
        //private readonly Content _content;
        //private readonly Comments Add_Comments;

        public AddContentController(Content Add_Content)
        {
            this.Add_Content = Add_Content;
           
        }

        [HttpGet]
        public IActionResult CAdd()
        {
            if(HttpContext.Session.GetString("AViewer")!=null) 
            { 
                return View();
            }
            else 
            {
                return RedirectToAction("Index","Home");
            }
            

        }
        [HttpPost]
        public async Task<IActionResult> CAdd(AddContentModel cnt)
        {
            var Kontent = new ContentModel()
            {
                ID = Guid.NewGuid(),
                Title = cnt.Title,
                Description = cnt.Description,
                Author = HttpContext.Session.GetString("AViewer"),
                CreatedAt = DateTime.Now

            };
            //var BGUID = Kontent.ID;
            //HttpContext.Session.SetString("gid", BGUID.ToString());

            await Add_Content.Contents.AddAsync(Kontent);
            await Add_Content.SaveChangesAsync();
            return RedirectToAction("Cview","ViewContent");
        }
        

    }
}

