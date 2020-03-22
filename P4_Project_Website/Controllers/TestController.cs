using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace P4_Project_Website.Controllers
{
    public class TestController : Controller
    {
        private static string myConnectionString = "data source=p4project.database.windows.net;Initial Catalog=P4; User ID=madol;Password=KanneKaffe123";

        // GET: Test_
        public ActionResult Index()
        {
            Console.WriteLine("hej jeg elsker tissemand, hov lag");
            return View();
        }

        // GET: Test_/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Test_/Create
        public ActionResult Create()
        {

            return View();

        }

        // POST: Test_/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {

            try
            {
                // TODO: Add insert logic here

                // connects to the database.
                using (SqlConnection cnn = new SqlConnection(myConnectionString))
                {

                    // create a variable with the query command
                    String query = "INSERT INTO Bruger (Fornavn,Efternavn,Brugernavn) VALUES (@Fornavn,@Efternavn,@Brugernavn)";

                    using (SqlCommand command = new SqlCommand(query, cnn))
                    {

                        command.Parameters.AddWithValue("@Fornavn", "abc");
                        command.Parameters.AddWithValue("@Efternavn", "abc");
                        command.Parameters.AddWithValue("@Brugernavn", "abc");

                        cnn.Open();
                        int result = command.ExecuteNonQuery();
                        cnn.Close();

                        // Check Error
                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");


                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Test_/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Test_/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Test_/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Test_/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}