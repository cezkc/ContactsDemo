using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactsDemoWebApp.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ContactsDemoWebApp.Controllers
{
    public class LegalPersonContactController : Controller
    {
        private const string _API_ENDPOINT = "http://localhost:61678/api/Contact/";
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
                ViewBag.Message = "Contact not found!";
                return RedirectToAction(nameof(Index));
            }

            var responseMessage = await httpClient.GetAsync(_API_ENDPOINT + $"LegalPerson/{id}");
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var legalPersonContactViewModel = JsonConvert.DeserializeObject<LegalPersonContactViewModel>(responseBody);

            if (legalPersonContactViewModel == null)
            {
                ViewBag.Message = "Contact not found!";
                return View(legalPersonContactViewModel);
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
                
                var valid = await APIErrorValidation(postResult);
                if (!valid)
                    return View(legalPersonContactViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(legalPersonContactViewModel);
        }

        // GET: LegalPersonContactViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                ViewBag.Message = "Contact not found!";
                return RedirectToAction(nameof(Index));
            }

            var responseMessage = await httpClient.GetAsync(_API_ENDPOINT + $"LegalPerson/{id}");
            var legalPersonContactList = new List<LegalPersonContactViewModel>();
            responseMessage.EnsureSuccessStatusCode();
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var legalPersonContactViewModel = JsonConvert.DeserializeObject<LegalPersonContactViewModel>(responseBody);

            if (legalPersonContactViewModel == null)
            {
                ViewBag.Message = "Contact not found!";
                return RedirectToAction(nameof(Index));
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
                ViewBag.Message = "Contact not found!";
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
                var jsonContent = JsonConvert.SerializeObject(legalPersonContactViewModel);
                var httpContent = new StringContent(jsonContent);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var postResult = await httpClient.PostAsync(_API_ENDPOINT + "LegalPerson", httpContent);

                var valid = await APIErrorValidation(postResult);
                if (!valid)
                    return View(legalPersonContactViewModel);

                return RedirectToAction(nameof(Index));
            }
            return View(legalPersonContactViewModel);
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

        // GET: LegalPersonContactViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                ViewBag.Message = "Contact not found!";
                return RedirectToAction(nameof(Index));
            }

            var responseMessage = await httpClient.GetAsync(_API_ENDPOINT + $"LegalPerson/{id}");
            var legalPersonContactList = new List<LegalPersonContactViewModel>();
            responseMessage.EnsureSuccessStatusCode();
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var legalPersonContactViewModel = JsonConvert.DeserializeObject<LegalPersonContactViewModel>(responseBody);
            if (legalPersonContactViewModel == null)
            {
                ViewBag.Message = "Contact not found!";
                return RedirectToAction(nameof(Index));
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
