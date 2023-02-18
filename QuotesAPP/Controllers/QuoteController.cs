using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuotesAPP.DAL;
using QuotesAPP.Services;
namespace QuotesAPP.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IQuoteService quoteService;
        private readonly IAuthorService authorService;

        public QuoteController(IQuoteService QouteService, IAuthorService authorService)
        {
            this.quoteService = QouteService;
            this.authorService = authorService;
        }

        // GET: Qoute
        public async Task<IActionResult> Index(string author)
        {
            ViewBag.Author = authorService.GetAuthors().Select(x=> x.Id);

            if (author != null)
                return View(quoteService.GetQuotesByAuthor(int.Parse(author)));
            return View(quoteService.GetQuotes());
            
        }


        // GET: Qoute/Create
        [HttpGet("Create")]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quote/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Text")] Quote quote)
        {
            if (ModelState.IsValid)
            {
                quote.AuthorId = int.Parse(User.Identity.GetUserId());
                quote.CreatedAt = DateTime.Now;
                quoteService.AddQuote(quote);
                return RedirectToAction(nameof(Index));
            }
            return View(quote);
        }

        // GET: Quote/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = quoteService.GetQuoteById((int)id);
            if (quote == null)
            {
                return NotFound();
            }
            return View(quote);
        }

        // POST: Quote/Edit/5
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Quote quote)
        {
            if (id != quote.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                quoteService.UpdateQuote(quote);
                return RedirectToAction(nameof(Index));
            }
            return View(quote);
        }

        // GET: Quote/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quote = quoteService.GetQuoteById((int)id);

            if (quote == null)
            {
                return NotFound();
            }

            return View(quote);
        }

        // POST: Quote/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quote = quoteService.GetQuoteById(id);
            quoteService.DeleteQuote(id);

            return RedirectToAction(nameof(Index));
        }

        private bool QuoteExists(int id)
        {
            return quoteService.QuoteExists(id);
        }
    }
}
