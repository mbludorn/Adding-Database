using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO; // important namespace for path
using System.Web.Security; //important namespace for membership

namespace MyBlogApplication.Controllers
{
    public class AccountController : Controller
    {
        //set up my data context
        Models.BlogEntities db = new Models.BlogEntities();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        //step 3 add the httpposttoedfilebase parameter
        [HttpPost]
        public ActionResult Register(Models.Registration registration, HttpPostedFileBase ImageURL)
        {
            if (ImageURL != null)
            {
                //save the image to our website
                //Guid genreates rando characters, that we can use to make sure the file name is not repeated
                string filename = Guid.NewGuid().ToString().Substring(0, 6) + ImageURL.FileName;

                //specify the path to save the file to
                //Server.MapPath actually gets the physical location of the website on the server
                string path = Path.Combine(Server.MapPath("~/content/"), filename);
                //SAVE the file
                ImageURL.SaveAs(path);
                //update oyr registration object, with the image
                registration.ImageURL = "/content/" + filename;
            }
            //create our membership user
            Membership.CreateUser(registration.Username, registration.Password);
            //create our author object
            Models.Author author = new Models.Author();
            author.Name = registration.Name;
            author.ImageURL = registration.ImageURL;
            author.Username = registration.Username;
           
            //add the author to the database
            db.Authors.Add(author);
            db.SaveChanges();


            //registration complete! log in the user 
            FormsAuthentication.SetAuthCookie(registration.Username, false);

            //kick the ser to the create post section
            return RedirectToAction("Index", "Post");
        }

        public ActionResult Logout()
        {
            //log out a user, do this
            FormsAuthentication.SignOut();

            //kick the user to the login screen
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Login login)
        {
            //see if they are a valid user
            if (Membership.ValidateUser(login.Username, login.Password))
            {

                //credetaials are gold, log them in
                FormsAuthentication.SetAuthCookie(login.Username, false);
                //kick the user to the create post page
                return RedirectToAction("Index", "Post");
            }

            else
            {
                //bad news bears, bad password or username
                ViewBag.ErrorMessage = "Invalid Username and/or Password";
                return View(login);
            }
        }
    }
}


