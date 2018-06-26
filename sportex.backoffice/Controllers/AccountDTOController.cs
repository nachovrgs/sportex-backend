using Newtonsoft.Json;
using sportex.backoffice.Configuration;
using sportex.backoffice.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace sportex.backoffice.Controllers
{
    public class AccountDTOController : Controller
    {
        // GET: AccountDTO
        public async Task<ActionResult> Index()
        {
            try
            {
                List<AccountDTO> accInfo = new List<AccountDTO>();
                using (var client = GlobalVariables.ApiClient())
                {
                    HttpResponseMessage res = await client.GetAsync("/api/Account");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var accResponse = res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the AccountDTO list  
                        accInfo = JsonConvert.DeserializeObject<List<AccountDTO>>(accResponse);

                    }
                    //returning the AccountDTO list to view  
                    return View(accInfo);
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // GET: AccountDTO/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    using (var client = GlobalVariables.ApiClient())
                    {
                        HttpResponseMessage res = await client.GetAsync("/api/Account/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;
                            AccountDTO accInfo = JsonConvert.DeserializeObject<AccountDTO>(accResponse);
                            return View(accInfo);
                        }
                    }
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // GET: AccountDTO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountDTO/Create
        [HttpPost]
        public async Task<ActionResult> Create(AccountDTO account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = GlobalVariables.ApiClient())
                    {
                        HttpResponseMessage res = await client.PostAsJsonAsync<AccountDTO>("/api/Account",account); 
                        if (res.IsSuccessStatusCode)
                        { 
                            var accResponse = res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the AccountDTO list  
                            //AccountDTO accInfo = JsonConvert.DeserializeObject<AccountDTO>(accResponse);
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // GET: AccountDTO/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    using (var client = GlobalVariables.ApiClient())
                    {
                        HttpResponseMessage res = await client.GetAsync("/api/Account/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;
                            AccountDTO accInfo = JsonConvert.DeserializeObject<AccountDTO>(accResponse);
                            return View(accInfo);
                        }
                    }
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(AccountDTO account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = GlobalVariables.ApiClient())
                    {
                        HttpResponseMessage res = await client.PutAsJsonAsync<AccountDTO>("/api/Account/" + account.ID, account);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }


        // GET: AccountDTO/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    using (var client = GlobalVariables.ApiClient())
                    {
                        HttpResponseMessage res = await client.GetAsync("/api/Account/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;
                            AccountDTO accInfo = JsonConvert.DeserializeObject<AccountDTO>(accResponse);
                            return View(accInfo);
                        }
                    }
                    return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // POST: AccountDTO/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int? id, AccountDTO account)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    using (var client = GlobalVariables.ApiClient())
                    {
                        HttpResponseMessage res = await client.DeleteAsync("/api/Account/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the AccountDTO list  
                            //AccountDTO accInfo = JsonConvert.DeserializeObject<AccountDTO>(accResponse);
                        }
                    }
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}
