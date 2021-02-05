using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactsDemoWebApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ContactsDemoWebApp.Controllers
{
    public class NaturalPersonContactController : Controller
    {
        private const string _API_ENDPOINT = "http://localhost:61678/api/Contact/";
        private static HttpClient httpClient = new HttpClient();

        public NaturalPersonContactController()
        {
        }

        private async Task<bool> APIErrorValidation(HttpResponseMessage postResult)
        {
            if (!postResult.IsSuccessStatusCode)
            {
                var responseBody = await postResult.Content.ReadAsStringAsync();
                var messages = JsonConvert.DeserializeObject<ErrorModel>(responseBody);
                StringBuilder errors = new StringBuilder();
                foreach (var message in messages.messages)
                    errors.AppendLine(message);
                ViewBag.Message = errors.ToString();
                return false;
            }
            return true;
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
                ViewBag.Message = "Contact not found!";
                return RedirectToAction(nameof(Index));
            }

            var responseMessage = await httpClient.GetAsync(_API_ENDPOINT + $"NaturalPerson/{id}");
            var legalPersonContactList = new List<NaturalPersonContactViewModel>();

            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var naturalPersonContactViewModel = JsonConvert.DeserializeObject<NaturalPersonContactViewModel>(responseBody);

            if (naturalPersonContactViewModel == null)
            {
                ViewBag.Message = "Contact not found!";
                return RedirectToAction(nameof(Index));
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

                var valid = await APIErrorValidation(postResult);
                if (!valid)
                    return View(naturalPersonContactViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(naturalPersonContactViewModel);
        }

        // GET: NaturalPersonContactViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Message = "Contact not found!";
                return RedirectToAction(nameof(Index));
            }

            var responseMessage = await httpClient.GetAsync(_API_ENDPOINT + $"NaturalPerson/{id}");
            var legalPersonContactList = new List<NaturalPersonContactViewModel>();
            responseMessage.EnsureSuccessStatusCode();
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var naturalPersonContactViewModel = JsonConvert.DeserializeObject<NaturalPersonContactViewModel>(responseBody);

            if (naturalPersonContactViewModel == null)
            {
                ViewBag.Message = "Contact not found!";
                return RedirectToAction(nameof(Index));
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
                ViewBag.Message = "Contact not found!";
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {

                var jsonContent = JsonConvert.SerializeObject(naturalPersonContactViewModel);
                var httpContent = new StringContent(jsonContent);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postResult = await httpClient.PostAsync(_API_ENDPOINT + "NaturalPerson", httpContent);
                postResult.EnsureSuccessStatusCode();
                
                var valid = await APIErrorValidation(postResult);
                if (!valid)
                    return View(naturalPersonContactViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(naturalPersonContactViewModel);
        }

        // GET: NaturalPersonContactViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ViewBag.Message = "Contact not found!";
                return RedirectToAction(nameof(Index));
            }

            var responseMessage = await httpClient.GetAsync(_API_ENDPOINT + $"NaturalPerson/{id}");
            var legalPersonContactList = new List<NaturalPersonContactViewModel>();
            responseMessage.EnsureSuccessStatusCode();
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var naturalPersonContactViewModel = JsonConvert.DeserializeObject<NaturalPersonContactViewModel>(responseBody);

            if (naturalPersonContactViewModel == null)
            {
                ViewBag.Message = "Contact not found!";
                return RedirectToAction(nameof(Index));
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
