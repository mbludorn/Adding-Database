using MyBlogApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MyBlogApplication.Controllers
{
    public class HomeController : Controller
    {
        Models.BlogEntities db = new Models.BlogEntities();
        //
        // GET: /Home/
        //private BlogEntities db = new BlogEntities();
        //public ActionResult Index()
        //{
        //    var posts = db.Posts.Include(p => p.Author);
        //    return View(posts.ToList());
        //}


        public ActionResult index()
        {
            
            return View(db.Posts.OrderByDescending(x => x.DateCreated));
        }

        public ActionResult AddComment(Models.Comment commentToAdd)
        {
            //make sure the comment is fully filled out
            commentToAdd.DateCreated = DateTime.Now;
           

            //add the comment to the database
            db.Comments.Add(commentToAdd);
            db.SaveChanges();

            //for now, until we AJAX it, we will kick the user back to the index
            //return RedirectToAction("Index", "Home");

            //ajaxd the psot method so we will return a partial view
            return PartialView("Comment", commentToAdd);
        }



        public ActionResult LikePost(int id)
        {
            //get the post from the database that matches the ID
            Models.Post thePostToLike = db.Posts.Find(id);
            //increment the likes by 1
            thePostToLike.Likes++;
            //save the changes to the database
            db.SaveChanges();
            //we need to return the number of likes
            return Content(thePostToLike.Likes + " likes");

        }
    }
}
