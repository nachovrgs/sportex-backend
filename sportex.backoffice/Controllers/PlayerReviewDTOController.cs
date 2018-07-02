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
    public class PlayerReviewDTOController : Controller
    {
        //// GET: PlayerReviewDTO
        //public async Task<ActionResult> Index()
        //{
        //    try
        //    {
        //        List<PlayerReviewDTO> accInfo = new List<PlayerReviewDTO>();
        //        using (var client = GlobalVariables.ApiClient())
        //        {
        //            HttpResponseMessage res = await client.GetAsync("/api/PlayerReview");

        //            //Checking the response is successful or not which is sent using HttpClient  
        //            if (res.IsSuccessStatusCode)
        //            {
        //                //Storing the response details recieved from web api   
        //                var accResponse = res.Content.ReadAsStringAsync().Result;

        //                //Deserializing the response recieved from web api and storing into the PlayerReviewDTO list  
        //                accInfo = JsonConvert.DeserializeObject<List<PlayerReviewDTO>>(accResponse);

        //            }
        //            //returning the PlayerReviewDTO list to view  
        //            return View(accInfo);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        //    }
        //}

        //// GET: PlayerReviewDTO/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    try
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        else
        //        {
        //            using (var client = GlobalVariables.ApiClient())
        //            {
        //                HttpResponseMessage res = await client.GetAsync("/api/PlayerReview/" + id);
        //                if (res.IsSuccessStatusCode)
        //                {
        //                    var accResponse = res.Content.ReadAsStringAsync().Result;
        //                    PlayerReviewDTO accInfo = JsonConvert.DeserializeObject<PlayerReviewDTO>(accResponse);
        //                    return View(accInfo);
        //                }
        //            }
        //            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        //    }
        //}

        //// GET: PlayerReviewDTO/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: PlayerReviewDTO/Create
        //[HttpPost]
        //public async Task<ActionResult> Create(PlayerReviewDTO review)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            using (var client = GlobalVariables.ApiClient())
        //            {
        //                HttpResponseMessage res = await client.PostAsJsonAsync<PlayerReviewDTO>("/api/PlayerReview", review);
        //                if (res.IsSuccessStatusCode)
        //                {
        //                    var accResponse = res.Content.ReadAsStringAsync().Result;

        //                    //Deserializing the response recieved from web api and storing into the PlayerReviewDTO list  
        //                    //PlayerReviewDTO accInfo = JsonConvert.DeserializeObject<PlayerReviewDTO>(accResponse);
        //                }
        //            }
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        //    }
        //}

        //// GET: PlayerReviewDTO/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    try
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        else
        //        {
        //            using (var client = GlobalVariables.ApiClient())
        //            {
        //                HttpResponseMessage res = await client.GetAsync("/api/PlayerReview/" + id);
        //                if (res.IsSuccessStatusCode)
        //                {
        //                    var accResponse = res.Content.ReadAsStringAsync().Result;
        //                    PlayerReviewDTO accInfo = JsonConvert.DeserializeObject<PlayerReviewDTO>(accResponse);
        //                    return View(accInfo);
        //                }
        //            }
        //            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        //    }
        //}

        //[HttpPost]
        //public async Task<ActionResult> Edit(PlayerReviewDTO review)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            using (var client = GlobalVariables.ApiClient())
        //            {
        //                HttpResponseMessage res = await client.PutAsJsonAsync<PlayerReviewDTO>("/api/PlayerReview/" + review.ID, review);
        //                if (res.IsSuccessStatusCode)
        //                {
        //                    var accResponse = res.Content.ReadAsStringAsync().Result;
        //                }
        //            }
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        //    }
        //}


        //// GET: PlayerReviewDTO/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    try
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        else
        //        {
        //            using (var client = GlobalVariables.ApiClient())
        //            {
        //                HttpResponseMessage res = await client.GetAsync("/api/PlayerReview/" + id);
        //                if (res.IsSuccessStatusCode)
        //                {
        //                    var accResponse = res.Content.ReadAsStringAsync().Result;
        //                    PlayerReviewDTO accInfo = JsonConvert.DeserializeObject<PlayerReviewDTO>(accResponse);
        //                    return View(accInfo);
        //                }
        //            }
        //            return new HttpStatusCodeResult(HttpStatusCode.NotFound);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        //    }
        //}

        //// POST: PlayerReviewDTO/Delete/5
        //[HttpPost]
        //public async Task<ActionResult> Delete(int? id, PlayerReviewDTO review)
        //{
        //    try
        //    {
        //        if (id == null)
        //        {
        //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //        }
        //        else
        //        {
        //            using (var client = GlobalVariables.ApiClient())
        //            {
        //                HttpResponseMessage res = await client.DeleteAsync("/api/PlayerReview/" + id);
        //                if (res.IsSuccessStatusCode)
        //                {
        //                    var accResponse = res.Content.ReadAsStringAsync().Result;

        //                    //Deserializing the response recieved from web api and storing into the PlayerReviewDTO list  
        //                    //PlayerReviewDTO accInfo = JsonConvert.DeserializeObject<PlayerReviewDTO>(accResponse);
        //                }
        //            }
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
        //    }
        //}
    }
}
