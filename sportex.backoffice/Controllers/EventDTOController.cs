using Newtonsoft.Json;
using sportex.backoffice.Configuration;
using sportex.backoffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace sportex.backoffice.Controllers
{
    public class EventDTOController : Controller
    {
        // GET: EventDTO
        public async Task<ActionResult> Index()
        {
            try
            {
                List<EventDTO> accInfo = new List<EventDTO>();
                using (var client = GlobalVariables.ApiClient())
                {
                    HttpResponseMessage res = await client.GetAsync("/api/Event");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var accResponse = res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the EventDTO list  
                        accInfo = JsonConvert.DeserializeObject<List<EventDTO>>(accResponse);

                    }
                    //returning the EventDTO list to view  
                    return View(accInfo);
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // GET: EventDTO/Details/5
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
                        HttpResponseMessage res = await client.GetAsync("/api/Event/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;
                            EventDTO accInfo = JsonConvert.DeserializeObject<EventDTO>(accResponse);
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

        // GET: EventDTO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventDTO/Create
        [HttpPost]
        public async Task<ActionResult> Create(EventDTO eve)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = GlobalVariables.ApiClient())
                    {
                        HttpResponseMessage res = await client.PostAsJsonAsync<EventDTO>("/api/Event", eve);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the EventDTO list  
                            //EventDTO accInfo = JsonConvert.DeserializeObject<EventDTO>(accResponse);
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

        // GET: EventDTO/Edit/5
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
                        HttpResponseMessage res = await client.GetAsync("/api/Event/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;
                            EventDTO accInfo = JsonConvert.DeserializeObject<EventDTO>(accResponse);
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
        public async Task<ActionResult> Edit(EventDTO eve)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = GlobalVariables.ApiClient())
                    {
                        HttpResponseMessage res = await client.PutAsJsonAsync<EventDTO>("/api/Event/" + eve.ID, eve);
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


        // GET: EventDTO/Delete/5
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
                        HttpResponseMessage res = await client.GetAsync("/api/Event/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;
                            EventDTO accInfo = JsonConvert.DeserializeObject<EventDTO>(accResponse);
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

        // POST: EventDTO/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int? id, EventDTO eve)
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
                        HttpResponseMessage res = await client.DeleteAsync("/api/Event/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the EventDTO list  
                            //EventDTO accInfo = JsonConvert.DeserializeObject<EventDTO>(accResponse);
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
