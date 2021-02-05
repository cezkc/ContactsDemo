using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactsDemoWebApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ContactsDemoWebApp.Controllers
{
    public class NaturalPersonContactController : Controller
    {
        private const string _API_ENDPOINT = "http://localhost:61678/api/Contact/";
        private static HttpClient httpClient = new HttpClient();

        public NaturalPersonContactController()
        {
        }

        // GET: NaturalPersonContactViewModels
        public async Task<IActionResult> Index()
        {
            var responseMessage = await httpClient.GetAsync(_API_ENDPOINT + "NaturalPerson");
            var naturalPersonContactList = new List<NaturalPersonContactViewModel>();
            responseMessage.EnsureSuccessStatusCode();
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            naturalPersonContactList = JsonConvert.DeserializeObject<List<NaturalPersonContactViewModel>>(responseBody);

            return View(naturalPersonContactList);
        }

        // GET: NaturalPersonContactViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var responseMessage = await httpClient.GetAsync(_API_ENDPOINT + $"NaturalPerson/{id}");
            var legalPersonContactList = new List<NaturalPersonContactViewModel>();
            responseMessage.EnsureSuccessStatusCode();
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var naturalPersonContactViewModel = JsonConvert.DeserializeObject<NaturalPersonContactViewModel>(responseBody);

            if (naturalPersonContactViewModel == null)
            {
                return NotFound();
            }

            return View(naturalPersonContactViewModel);
        }

        // GET: NaturalPersonContactViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NaturalPersonContactViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Birthday,CPF,ZipCode,Country,State,City,AddressLine1,AddressLine2")] NaturalPersonContactViewModel naturalPersonContactViewModel)
        {
            if (ModelState.IsValid)
            {
                var jsonContent = JsonConvert.SerializeObject(naturalPersonContactViewModel);
                var httpContent = new StringContent(jsonContent);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postResult = await httpClient.PostAsync(_API_ENDPOINT + "NaturalPerson", httpContent);
                postResult.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            return View(naturalPersonContactViewModel);
        }

        // GET: NaturalPersonContactViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responseMessage = await httpClient.GetAsync(_API_ENDPOINT + $"NaturalPerson/{id}");
            var legalPersonContactList = new List<NaturalPersonContactViewModel>();
            responseMessage.EnsureSuccessStatusCode();
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var naturalPersonContactViewModel = JsonConvert.DeserializeObject<NaturalPersonContactViewModel>(responseBody);

            if (naturalPersonContactViewModel == null)
            {
                return NotFound();
            }
            return View(naturalPersonContactViewModel);
        }

        // POST: NaturalPersonContactViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,Birthday,CPF,ZipCode,Country,State,City,AddressLine1,AddressLine2")] NaturalPersonContactViewModel naturalPersonContactViewModel)
        {
            if (id != naturalPersonContactViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var jsonContent = JsonConvert.SerializeObject(naturalPersonContactViewModel);
                    var httpContent = new StringContent(jsonContent);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var postResult = await httpClient.PostAsync(_API_ENDPOINT + "NaturalPerson", httpContent);
                    postResult.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(naturalPersonContactViewModel);
        }

        // GET: NaturalPersonContactViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responseMessage = await httpClient.GetAsync(_API_ENDPOINT + $"NaturalPerson/{id}");
            var legalPersonContactList = new List<NaturalPersonContactViewModel>();
            responseMessage.EnsureSuccessStatusCode();
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var naturalPersonContactViewModel = JsonConvert.DeserializeObject<NaturalPersonContactViewModel>(responseBody);

            if (naturalPersonContactViewModel == null)
            {
                return NotFound();
            }

            return View(naturalPersonContactViewModel);
        }

        // POST: NaturalPersonContactViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var responseMessage = await httpClient.DeleteAsync(_API_ENDPOINT + $"{id}");
            responseMessage.EnsureSuccessStatusCode();
            return RedirectToAction(nameof(Index));
        }
    }
}
