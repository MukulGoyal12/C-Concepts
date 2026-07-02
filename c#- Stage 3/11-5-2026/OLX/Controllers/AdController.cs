using AuctionAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OLX.Controllers
{
    public class AdController : Controller
    {
        HttpClient client=new HttpClient();
        public AdController()
        {
            client.BaseAddress = new Uri("http://localhost:5277/");
        }
        // GET: AdController
        //public async Task<List<Advertisement>> Index()
        //{
        //    client.BaseAddress = new Uri("http://localhost:5277/");
        //    var result = await client.GetAsync("api/Advertisement");
        //    if (result.IsSuccessStatusCode)
        //    {
        // // returns json data and convert it to list of advertisement
        //        return await result.Content.ReadFromJsonAsync<List<Advertisement>>();
        //    }
        //    return null;

        //}
        public async Task<IActionResult> Index()
        {
            List<Advertisement> ads = new List<Advertisement>();
           
            var result = await client.GetAsync("api/Advertisement");
            if (result.IsSuccessStatusCode)
            {
                ads = await result.Content.ReadFromJsonAsync<List<Advertisement>>();

            }

            return View(ads);
        }

        // GET: AdController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Advertisement ad=null;
            var result = await client.GetAsync($"api/Advertisement/{id}");
            if (result.IsSuccessStatusCode)
            {
               ad  =  await result.Content.ReadFromJsonAsync<Advertisement>();

            }
            return View(ad);
        }

        // GET: AdController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AdvertisementDTO newad)
        {
            try
            {
               await  client.PostAsJsonAsync("api/Advertisement", newad);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Advertisement ad = null;
            var result = await client.GetAsync($"api/Advertisement/{id}");
            if (result.IsSuccessStatusCode)
            {
                ad = await result.Content.ReadFromJsonAsync<Advertisement>();

            }
            return View(ad);
        }

        // POST: AdController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, AdvertisementDTO newad)
        {
            
            try
            {
                    var result = await client.PutAsJsonAsync($"api/Advertisement/{id}", newad);
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: AdController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Advertisement ad = null;
            var result = await client.GetAsync($"api/Advertisement/{id}");
            if (result.IsSuccessStatusCode)
            {
                ad = await result.Content.ReadFromJsonAsync<Advertisement>();

            }
            return View(ad);
        }

        // POST: AdController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Advertisement collection)
        {
            try
            {
               await client.DeleteAsync($"api/Advertisement/{id}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
