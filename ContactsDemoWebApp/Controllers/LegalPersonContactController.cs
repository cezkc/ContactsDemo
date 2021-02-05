using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactsDemoWebApp.Data;
using ContactsDemoWebApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ContactsDemoWebApp.Controllers
{
    public class LegalPersonContactController : Controller
    {
        private const string _API_ENDPOINT = "http://localhost:61678/api/Contact/";
        private readonly ContactsDemoWebAppContext _context;
        private static HttpClient httpClient = new HttpClient();
        public LegalPersonContactController()
        {
        }

        // GET: LegalPersonContactViewModels
        public async Task<IActionResult> Index()
        {
            var responseMessage = await httpClient.GetAsync(_API_ENDPOINT + "LegalPerson");
            var legalPersonContactList = new List<LegalPersonContactViewModel>();
            responseMessage.EnsureSuccessStatusCode();
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            legalPersonContactList = JsonConvert.DeserializeObject<List<LegalPersonContactViewModel>>(responseBody);
            return View(legalPersonContactList);
        }

        // GET: LegalPersonContactViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responseMessage = await httpClient.GetAsync(_API_ENDPOINT + $"LegalPerson/{id}");
            var legalPersonContactList = new List<LegalPersonContactViewModel>();
            responseMessage.EnsureSuccessStatusCode();
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var legalPersonContactViewModel = JsonConvert.DeserializeObject<LegalPersonContactViewModel>(responseBody);

            if (legalPersonContactViewModel == null)
            {
                return NotFound();
            }

            return View(legalPersonContactViewModel);
        }

        // GET: LegalPersonContactViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LegalPersonContactViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,TradeName,CNPJ,ZipCode,Country,State,City,AddressLine1,AddressLine2")] LegalPersonContactViewModel legalPersonContactViewModel)
        {
            if (ModelState.IsValid)
            {
                var jsonContent = JsonConvert.SerializeObject(legalPersonContactViewModel);
                var httpContent = new StringContent(jsonContent);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postResult = await httpClient.PostAsync(_API_ENDPOINT + "LegalPerson", httpContent);
                postResult.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            return View(legalPersonContactViewModel);
        }

        // GET: LegalPersonContactViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responseMessage = await httpClient.GetAsync(_API_ENDPOINT + $"LegalPerson/{id}");
            var legalPersonContactList = new List<LegalPersonContactViewModel>();
            responseMessage.EnsureSuccessStatusCode();
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var legalPersonContactViewModel = JsonConvert.DeserializeObject<LegalPersonContactViewModel>(responseBody);

            //var legalPersonContactViewModel = await _context.LegalPersonContactViewModel.FindAsync(id);
            if (legalPersonContactViewModel == null)
            {
                return NotFound();
            }
            return View(legalPersonContactViewModel);
        }

        // POST: LegalPersonContactViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,TradeName,CNPJ,ZipCode,Country,State,City,AddressLine1,AddressLine2")] LegalPersonContactViewModel legalPersonContactViewModel)
        {
            if (id != legalPersonContactViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var jsonContent = JsonConvert.SerializeObject(legalPersonContactViewModel);
                    var httpContent = new StringContent(jsonContent);
                    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    var postResult = await httpClient.PostAsync(_API_ENDPOINT + "LegalPerson", httpContent);
                    postResult.EnsureSuccessStatusCode();
                }
                catch (Exception ex)
                {

                    throw;

                }
                return RedirectToAction(nameof(Index));
            }
            return View(legalPersonContactViewModel);
        }

        // GET: LegalPersonContactViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var responseMessage = await httpClient.GetAsync(_API_ENDPOINT + $"LegalPerson/{id}");
            var legalPersonContactList = new List<LegalPersonContactViewModel>();
            responseMessage.EnsureSuccessStatusCode();
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var legalPersonContactViewModel = JsonConvert.DeserializeObject<LegalPersonContactViewModel>(responseBody);
            if (legalPersonContactViewModel == null)
            {
                return NotFound();
            }

            return View(legalPersonContactViewModel);
        }

        // POST: LegalPersonContactViewModels/Delete/5
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
