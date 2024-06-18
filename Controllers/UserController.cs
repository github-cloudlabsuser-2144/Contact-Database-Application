using CRUD_application_2.Models;
using System.Linq;
using System.Web.Mvc;
 
namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
        // GET: User
        public ActionResult Index()
        {
            // Implement the Index method here


            return View(userlist);
        }
 
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            //get the user with the specified ID from the userlist

            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);





        }
 
        // GET: User/Create
        public ActionResult Create()
        {
            //Implement the Create method here
            return View(userlist);


        }
 
        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Implement the Create method (POST) here
            if (ModelState.IsValid)
            {
                userlist.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
 
        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // This method is responsible for displaying the view to edit an existing user with the specified ID.
            // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.

            var user = userlist.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return HttpNotFound();
            }

                return View(user);
        }
 
        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
            // It receives user input from the form submission and updates the corresponding user's information in the userlist.
            // If successful, it redirects to the Index action to display the updated list of users.
            // If no user is found with the provided ID, it returns a HttpNotFoundResult.
            // If an error occurs during the process, it returns the Edit view to display any validation errors.
            // POST: User/Edit/5
            
                var userToUpdate = userlist.FirstOrDefault(u => u.Id == id);
                if (userToUpdate == null)
                {
                    return HttpNotFound();
                }
                if (ModelState.IsValid)
                {
                    // Assuming User class has properties that you want to update.
                    // Update the properties of userToUpdate with the values from user
                    // For example:
                    // userToUpdate.Name = user.Name;
                    // userToUpdate.Email = user.Email;
                    // Add similar lines for other properties you wish to update

                    // After updating the properties, redirect to the Index view
                    return RedirectToAction("Index");
                }
                // If model state is not valid, return the Edit view with the user object to display validation errors
                return View(user);
     


        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Implement the Delete method here

                var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
                {
                    return HttpNotFound();
                }
            userlist.Remove(user);
            return RedirectToAction("Index");

        }
 
        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            // Implement the Delete method (POST) here
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            userlist.Remove(user);
            return RedirectToAction("Index");



        }
    }
}
