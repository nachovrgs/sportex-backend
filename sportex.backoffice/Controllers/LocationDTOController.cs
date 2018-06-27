﻿using Newtonsoft.Json;
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
    public class LocationDTOController : Controller
    {
        // GET: LocationDTO
        public async Task<ActionResult> Index()
        {
            try
            {
                List<LocationDTO> accInfo = new List<LocationDTO>();
                using (var client = GlobalVariables.ApiClient())
                {
                    HttpResponseMessage res = await client.GetAsync("/api/Location");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var accResponse = res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the LocationDTO list  
                        accInfo = JsonConvert.DeserializeObject<List<LocationDTO>>(accResponse);

                    }
                    //returning the LocationDTO list to view  
                    return View(accInfo);
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // GET: LocationDTO/Details/5
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
                        HttpResponseMessage res = await client.GetAsync("/api/Location/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;
                            LocationDTO accInfo = JsonConvert.DeserializeObject<LocationDTO>(accResponse);
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

        // GET: LocationDTO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationDTO/Create
        [HttpPost]
        public async Task<ActionResult> Create(LocationDTO location)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = GlobalVariables.ApiClient())
                    {
                        HttpResponseMessage res = await client.PostAsJsonAsync<LocationDTO>("/api/Location", location);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the LocationDTO list  
                            //LocationDTO accInfo = JsonConvert.DeserializeObject<LocationDTO>(accResponse);
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

        // GET: LocationDTO/Edit/5
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
                        HttpResponseMessage res = await client.GetAsync("/api/Location/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;
                            LocationDTO accInfo = JsonConvert.DeserializeObject<LocationDTO>(accResponse);
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
        public async Task<ActionResult> Edit(LocationDTO location)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = GlobalVariables.ApiClient())
                    {
                        HttpResponseMessage res = await client.PutAsJsonAsync<LocationDTO>("/api/Location/" + location.ID, location);
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


        // GET: LocationDTO/Delete/5
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
                        HttpResponseMessage res = await client.GetAsync("/api/Location/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;
                            LocationDTO accInfo = JsonConvert.DeserializeObject<LocationDTO>(accResponse);
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

        // POST: LocationDTO/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int? id, LocationDTO location)
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
                        HttpResponseMessage res = await client.DeleteAsync("/api/Location/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the LocationDTO list  
                            //LocationDTO accInfo = JsonConvert.DeserializeObject<LocationDTO>(accResponse);
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
