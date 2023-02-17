using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public QuoteController(IQuoteService QouteService)
        {
            this.quoteService = QouteService;
        }

        // GET: Qoute
        public async Task<IActionResult> Index()
        {
            return View(quoteService.GetQuotes());
        }


        // GET: Qoute/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quote/Create
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Quote quote)
        {
            if (ModelState.IsValid)
            {
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
