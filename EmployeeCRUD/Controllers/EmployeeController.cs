using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee.Core.Data;
using Employee.Data;
using Employee.Service;
using EmployeeCRUD.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace EmployeeCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        string apiUrl = System.Configuration.ConfigurationManager.AppSettings["ApiUrl"];

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<EmployeeModel> employees = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<EmployeeModel>>();
                    readTask.Wait();
                    employees = readTask.Result;
                }
                else
                {
                    employees = Enumerable.Empty<EmployeeModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(employees);
        }

        [HttpGet]
        public ActionResult CreateEditEmployee(int? id)
        {
            EmployeeModel model = new EmployeeModel();
            if (id != null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl + "/" + id);
                    var responseTask = client.GetAsync(client.BaseAddress);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<EmployeeModel>();
                        readTask.Wait();
                        model = readTask.Result;
                    }
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEditEmployee(EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ID == 0)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(apiUrl);
                        var postTask = client.PostAsJsonAsync<EmployeeModel>(client.BaseAddress, model);
                        postTask.Wait();
                        var result = postTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                else
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(apiUrl + "/" + model.ID);
                        var responseTask = client.PutAsJsonAsync<EmployeeModel>(client.BaseAddress, model);
                        responseTask.Wait();
                        var result = responseTask.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }

            }
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteEmployee()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                if (id != 0)
                {
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(apiUrl + "/" + id);
                        var deleteTask = client.DeleteAsync(client.BaseAddress);
                        deleteTask.Wait();
                        var result = deleteTask.Result;
                        if (result.IsSuccessStatusCode)
                        {

                            return RedirectToAction("Index");
                        }
                    }                   
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        
    }
}