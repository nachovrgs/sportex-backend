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
    public class GroupDTOController : Controller
    {
        public async Task<ActionResult> Index()
        {
            try
            {
                List<GroupDTO> accInfo = new List<GroupDTO>();
                using (var client = GlobalVariables.ApiClient())
                {
                    HttpResponseMessage res = await client.GetAsync("/api/Group");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var accResponse = res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the GroupDTO list  
                        accInfo = JsonConvert.DeserializeObject<List<GroupDTO>>(accResponse);

                    }
                    //returning the GroupDTO list to view  
                    return View(accInfo);
                }
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }

        // GET: GroupDTO/Details/5
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
                        HttpResponseMessage res = await client.GetAsync("/api/Group/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;
                            GroupDTO accInfo = JsonConvert.DeserializeObject<GroupDTO>(accResponse);
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

        // GET: GroupDTO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupDTO/Create
        [HttpPost]
        public async Task<ActionResult> Create(GroupDTO group)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = GlobalVariables.ApiClient())
                    {
                        HttpResponseMessage res = await client.PostAsJsonAsync<GroupDTO>("/api/Group", group);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the GroupDTO list  
                            //GroupDTO accInfo = JsonConvert.DeserializeObject<GroupDTO>(accResponse);
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

        // GET: GroupDTO/Edit/5
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
                        HttpResponseMessage res = await client.GetAsync("/api/Group/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;
                            GroupDTO accInfo = JsonConvert.DeserializeObject<GroupDTO>(accResponse);
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
        public async Task<ActionResult> Edit(GroupDTO group)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = GlobalVariables.ApiClient())
                    {
                        HttpResponseMessage res = await client.PutAsJsonAsync<GroupDTO>("/api/Group/" + group.ID, group);
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


        // GET: GroupDTO/Delete/5
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
                        HttpResponseMessage res = await client.GetAsync("/api/Group/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;
                            GroupDTO accInfo = JsonConvert.DeserializeObject<GroupDTO>(accResponse);
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

        // POST: GroupDTO/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int? id, GroupDTO group)
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
                        HttpResponseMessage res = await client.DeleteAsync("/api/Group/" + id);
                        if (res.IsSuccessStatusCode)
                        {
                            var accResponse = res.Content.ReadAsStringAsync().Result;

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

        public async Task<ActionResult> LeaveGroup(int? idProf, int? idGroup)
        {
            try
            {
                if (idProf == null || idGroup == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    using (var client = GlobalVariables.ApiClient())
                    {
                        HttpResponseMessage res = await client.PostAsJsonAsync("/api/Group/LeaveGroup", new { idProfile = idProf, idGroup = idGroup });
                        if (res.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Details/" + idGroup);
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
    }
}
