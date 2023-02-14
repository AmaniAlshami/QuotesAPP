using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using QuotesAPP.DAL;
namespace QuotesAPP.Pages
{
    public class QuotesModel : PageModel
    {

        private readonly string baseURL = "https://localhost:7213/api/";
 

        //https://quotesapp-2023.azurewebsites.net/api/
        public async Task<IEnumerable<Quote>> GetQuotes()
        {
            using HttpClient client = new HttpClient();
            string url = new Uri($"{baseURL}qoute/List").ToString();
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Quote>>(data);
        }

        public async Task<Quote> GetRandomQuote()
        {
            using HttpClient client = new HttpClient();
            string url = new Uri($"{baseURL}qoute/random").ToString();
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Quote>(data);
        }

        public async Task<IEnumerable<Quote>> GetQuotesByAuthor(int authorId)
        {
            using HttpClient client = new HttpClient();
            string url = new Uri($"{baseURL}/api/author/{authorId}/quotes").ToString();
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.GetAsync(url);
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Quote>>(data);
        }
    }
}
