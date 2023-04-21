using BLOG.Data;
using BLOG.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BLOG.Controllers
{
    public class ViewContentController : Controller
    {

       

        private readonly Content _content;
        private readonly Comments Add_Comments;
       
        private readonly UserPostLikes ULike;

        public ViewContentController(Content _content, Comments Add_Comments, UserPostLikes ULike)
        {

            this._content = _content;
            this.Add_Comments = Add_Comments;
            this.ULike = ULike;
           
           
        }


        public async Task<IActionResult> Cview()
        {
            var ViewKontent = await _content.Contents.ToListAsync();
            var ViewComment = await Add_Comments.Comment.ToListAsync();
            TempData["Blog"] = ViewKontent;
            TempData["Comment"] = ViewComment;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlog(Guid id)
        {
            if (HttpContext.Session.GetString("AViewer") != null)
            {
                var Cblog = await _content.Contents.FirstOrDefaultAsync(up => up.ID == id);
                if (Cblog != null)
                {
                    var viewModel = new Content_Update()
                    {
                        ID = Cblog.ID,
                        Description = Cblog.Description,
                        Title = Cblog.Title
                    }; return await Task.Run(() => View("UpdateBlog", viewModel));

                }

                return View(Cblog);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(ContentModel cmt)
        {
            if (HttpContext.Session.GetString("AViewer") != null)
            {
                var Ublog = await _content.Contents.FindAsync(cmt.ID);
                if (Ublog != null)
                {
                    Ublog.Title = cmt.Title;
                    Ublog.Description = cmt.Description;
                    await _content.SaveChangesAsync();
                    return RedirectToAction("Cview");

                }
                return NotFound();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteContent(Guid id)

        {
            if (HttpContext.Session.GetString("AViewer") != null)
            {
                var blog = await _content.Contents.FirstOrDefaultAsync(c => c.ID == id);


                if (blog != null)
                {
                    _content.Contents.Remove(blog);
                    await _content.SaveChangesAsync();


                    return RedirectToAction("Cview");

                }
                return NotFound();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddCom(AddComments cmt, Guid blogPostId)
        {
            if (HttpContext.Session.GetString("UViewer") != null)
            {
                //string guidString = HttpContext.Session.GetString("gid");
                //Guid BGUID = Guid.Parse(guidString);

                var Koment = new UComments()
                {
                    ID = Guid.NewGuid(),
                    UComment = cmt.UComment,
                    Uname = HttpContext.Session.GetString("UViewer"),
                    BlogPostId = blogPostId
                };
                await Add_Comments.Comment.AddAsync(Koment);
                await Add_Comments.SaveChangesAsync();
                return RedirectToAction("Cview");
            }
            else
            {
                return View("AddCom");
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditComment(Guid id)
        {
            string guidString = HttpContext.Session.GetString("UID");
            Guid CGUID = Guid.Parse(guidString);
            if (CGUID != null)
            {
                var comment = await Add_Comments.Comment.FirstOrDefaultAsync(c => c.ID == id);


                if (comment != null)
                {

                    var viewModel = new UpdateComment()
                    {
                        ID = comment.ID,
                        UComment = comment.UComment,
                    };
                    return await Task.Run(() => View("EditComment", viewModel));

                }

                return View(comment);
            }
            else
            {
                return View("Cview");
            }

        }




        [HttpPost]
        public async Task<IActionResult> EditComment(UComments comment)
        {
            string guidString = HttpContext.Session.GetString("UID");
            Guid CGUID = Guid.Parse(guidString);
            if (CGUID != null)
            {
                //var commentToUpdate = await Add_Comments.Comment.FirstOrDefaultAsync(c => c.ID == comment.ID);
                var commentToUpdate = await Add_Comments.Comment.FindAsync(comment.ID);


                if (commentToUpdate != null)
                {

                    commentToUpdate.UComment = comment.UComment;
                    await Add_Comments.SaveChangesAsync();
                    return RedirectToAction("Cview");

                }
                return NotFound();
            }
            else
            {
                return View("Cview");
            }

        }
        [HttpPost]
        public async Task<IActionResult> DeleteComment(Guid id)

        {
            if (HttpContext.Session.GetString("UViewer") != null)
            {
                var comment = await Add_Comments.Comment.FirstOrDefaultAsync(c => c.ID == id);


                if (comment != null)
                {

                    Add_Comments.Comment.Remove(comment);
                    await Add_Comments.SaveChangesAsync();


                    return RedirectToAction("Cview");

                }
                return NotFound();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
               
        public async Task<IActionResult> LikePost(Guid id)
        {
           
            if (HttpContext.Session.GetString("UID") == null) { return RedirectToAction("Cview"); }
            var userId = Guid.Parse(HttpContext.Session.GetString("UID"));
            var existingLike = await ULike.Likes.FirstOrDefaultAsync(upl => upl.UserId == userId && upl.PostId == id);
            if (existingLike != null)
            {
                return RedirectToAction("Cview");
            }


            var Cblog = await _content.Contents.FirstOrDefaultAsync(up => up.ID == id);
                if (Cblog != null)
                {

                    Cblog.LikeCount += 1;

                    


                    var Ublog = await _content.Contents.FindAsync(id);
                    if (Ublog != null)
                    {
                        Ublog.LikeCount = Cblog.LikeCount;

                        await _content.SaveChangesAsync();
                    }

                    


                var newUserPostLike = new UserPostLike 
                {    
                    UserId = userId, 
                    PostId = id 
                };
                ULike.Likes.Add(newUserPostLike);
                await ULike.SaveChangesAsync();
                return RedirectToAction("Cview");


                }
                return NotFound();
            }
           
        


    }


}
