using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using QuotesAPP.DAL;

namespace QuotesAPP.Pages
{
    public class AuthorsModel : PageModel
    {
        public void OnGet()
        {

        }
        private readonly string baseURL = "https://localhost:7213/api/";

        public async Task<IEnumerable<Quote>> GetQuotesByAuthor(int authorId)
        {
            using HttpClient client = new HttpClient();
            string url = new Uri($"{baseURL}author/{authorId}/quotes").ToString();
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Quote>>(data);
        }

        public async Task<IEnumerable<Author>> GetAuthors()
        {
            using HttpClient client = new HttpClient();
            string url = new Uri($"{baseURL}author/list").ToString();
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Author>>(data);
            //return authors.Select(x => x.Name);
        }
    }
}
