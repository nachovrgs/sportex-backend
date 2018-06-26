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
    public class StandardProfileDTOController : Controller
    {
        // GET: StandardProfileDTO
        public async Task<ActionResult> Index()
        {
            try
            {
                List<StandardProfileDTO> accInfo = new List<StandardProfileDTO>();
                using (var client = GlobalVariables.ApiClient())
                {
                    HttpResponseMessage res = await client.GetAsync("/api/StandardProfile");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var accResponse = res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the StandardProfileDTO list  
                        accInfo = JsonConvert.DeserializeObject<List<StandardProfileDTO>>(accResponse);

                    }
                    //returning the StandardProfileDTO list to view  
                    return View(accInfo);
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // GET: StandardProfileDTO/Details/5
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
                        HttpResponseMessage res = await client.GetAsync("/api/StandardProfile/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;
                            StandardProfileDTO accInfo = JsonConvert.DeserializeObject<StandardProfileDTO>(accResponse);
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

        // GET: StandardProfileDTO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StandardProfileDTO/Create
        [HttpPost]
        public async Task<ActionResult> Create(StandardProfileDTO profile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = GlobalVariables.ApiClient())
                    {
                        HttpResponseMessage res = await client.PostAsJsonAsync<StandardProfileDTO>("/api/StandardProfile", profile);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the StandardProfileDTO list  
                            //StandardProfileDTO accInfo = JsonConvert.DeserializeObject<StandardProfileDTO>(accResponse);
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // GET: StandardProfileDTO/Edit/5
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
                        HttpResponseMessage res = await client.GetAsync("/api/StandardProfile/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;
                            StandardProfileDTO accInfo = JsonConvert.DeserializeObject<StandardProfileDTO>(accResponse);
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
        public async Task<ActionResult> Edit(StandardProfileDTO profile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = GlobalVariables.ApiClient())
                    {
                        HttpResponseMessage res = await client.PutAsJsonAsync<StandardProfileDTO>("/api/StandardProfile/" + profile.ID, profile);
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


        // GET: StandardProfileDTO/Delete/5
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
                        HttpResponseMessage res = await client.GetAsync("/api/StandardProfile/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;
                            StandardProfileDTO accInfo = JsonConvert.DeserializeObject<StandardProfileDTO>(accResponse);
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

        // POST: StandardProfileDTO/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int? id, StandardProfileDTO profile)
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
                        HttpResponseMessage res = await client.DeleteAsync("/api/StandardProfile/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the StandardProfileDTO list  
                            //StandardProfileDTO accInfo = JsonConvert.DeserializeObject<StandardProfileDTO>(accResponse);
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
